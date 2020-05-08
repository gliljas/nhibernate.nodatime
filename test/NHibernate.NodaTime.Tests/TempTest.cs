using FluentAssertions;
using NHibernate.Engine;
using NHibernate.Mapping.ByCode;
using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class TempTest : IClassFixture<NHibernateFixture>, IDisposable
    {
        private readonly NHibernateFixture _nhibernateFixture;

        public TempTest(NHibernateFixture nhibernateFixture)
        {
            _nhibernateFixture = nhibernateFixture;
            _nhibernateFixture.Configure(c =>
            {

                var mapper = new ModelMapper();
                mapper.Class<MyTestEntity>(ca =>
                {
                    ca.Id(x => x.Id, map => map.Generator(Generators.Identity));
                    ca.Property(x => x.TestProperty, map =>
                    {
                        map.Type<DoublePropertyStructUserType>();
                        map.Columns(x => x.Name("Value1"), x => x.Name("Value2"));
                    });
                });
                var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                c.AddMapping(mapping);

            });
        }

		public void Dispose()
		{
			using (ISession session = _nhibernateFixture.SessionFactory.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Delete("from MyTestEntity");
				transaction.Commit();
			}
		}

		[Fact]
		public void Test()
		{
			using (ISession session = _nhibernateFixture.SessionFactory.OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				session.Save(new MyTestEntity { TestProperty = new DoublePropertyStruct(new SinglePropertyStruct("123456"), new SinglePropertyStruct("123456")) });
				session.Save(new MyTestEntity { TestProperty = new DoublePropertyStruct(new SinglePropertyStruct("123456"), new SinglePropertyStruct("23456")) });
				transaction.Commit();
			}

			var testValue = new DoublePropertyStruct(new SinglePropertyStruct("123456"), new SinglePropertyStruct("123456"));
			using (var session = _nhibernateFixture.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				var entities = session.Query<MyTestEntity>().Where(x => x.TestProperty == testValue).ToList();
				entities.Count().Should().Be(1);
			}
		}

		
    }

	public class MyTestEntity
	{
		public virtual int Id { get; set; }
		public virtual DoublePropertyStruct TestProperty { get; set; }
	}

	public struct SinglePropertyStruct //: IEquatable<SinglePropertyStruct>
	{
		public SinglePropertyStruct(string value)
		{
			Value = value;
		}
		public string Value { get; private set; }

		public override bool Equals(object obj)
		{
			return obj is SinglePropertyStruct @struct && Equals(@struct);
		}

		public bool Equals(SinglePropertyStruct other)
		{
			return Value == other.Value;
		}

		public override int GetHashCode()
		{
			return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
		}

		public static bool operator ==(SinglePropertyStruct d1, SinglePropertyStruct d2)
		{
			return d1.Equals(d2);
		}

		public static bool operator !=(SinglePropertyStruct d1, SinglePropertyStruct d2)
		{
			return !d1.Equals(d2);
		}
	}

	public struct DoublePropertyStruct : IEnumerable<SinglePropertyStruct>
	{
		public DoublePropertyStruct(SinglePropertyStruct value1, SinglePropertyStruct value2)
		{
			Value1 = value1;
			Value2 = value2;
		}
		public SinglePropertyStruct Value1 { get; private set; }
		public SinglePropertyStruct Value2 { get; private set; }

		public override bool Equals(object obj)
		{
			return obj is DoublePropertyStruct @struct &&
				   EqualityComparer<SinglePropertyStruct>.Default.Equals(Value1, @struct.Value1) &&
				   EqualityComparer<SinglePropertyStruct>.Default.Equals(Value2, @struct.Value2);
		}

		public IEnumerator<SinglePropertyStruct> GetEnumerator()
		{
			return new List<SinglePropertyStruct> { 
				Value1,
				Value2
			}.GetEnumerator();
		}

		public override int GetHashCode()
		{
			int hashCode = -1959444751;
			hashCode = hashCode * -1521134295 + Value1.GetHashCode();
			hashCode = hashCode * -1521134295 + Value2.GetHashCode();
			return hashCode;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static bool operator ==(DoublePropertyStruct d1, DoublePropertyStruct d2)
		{
			return d1.Equals(d2);
		}

		public static bool operator !=(DoublePropertyStruct d1, DoublePropertyStruct d2)
		{
			return !d1.Equals(d2);
		}
	}

	public class SinglePropertyStructUserType : IUserType
	{
		public SqlType[] SqlTypes => new[] { SqlTypeFactory.GetString(10) };

		public System.Type ReturnedType => typeof(SinglePropertyStruct);

		public bool IsMutable => false;

		public object Assemble(object cached, object owner) => cached;

		public object DeepCopy(object value) => value;

		public object Disassemble(object value) => value;

		public new bool Equals(object x, object y)
		{
			return object.Equals(x, y);
		}

		public int GetHashCode(object x)
		{
			return x?.GetHashCode() ?? 0;
		}

		public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
		{
			var value = (string)rs[names[0]];
			return new SinglePropertyStruct(value);
		}

		public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
		{
			cmd.Parameters[index].Value = ((SinglePropertyStruct)value).Value;
		}

		public object Replace(object original, object target, object owner)
		{
			return original;
		}
	}

	public class DoublePropertyStructUserType : ICompositeUserType
	{
		public string[] PropertyNames => new[] { "Value1", "Value2" };

		public IType[] PropertyTypes => new IType[] { new CustomType<SinglePropertyStructUserType>(), new CustomType<SinglePropertyStructUserType>() };

		public System.Type ReturnedClass => typeof(DoublePropertyStruct);

		public bool IsMutable => false;

		public object Assemble(object cached, ISessionImplementor session, object owner) => false;

		public object DeepCopy(object value) => value;

		public object Disassemble(object value, ISessionImplementor session) => value;

		public new bool Equals(object x, object y)
		{
			return object.Equals(x, y);
		}

		public int GetHashCode(object x)
		{
			return x?.GetHashCode() ?? 0;
		}

		public object GetPropertyValue(object component, int property)
		{
			var value = (DoublePropertyStruct)component;
			switch (property)
			{
				case 0:
					return value.Value1;
				case 1:
					return value.Value2;
			}
			throw new ArgumentOutOfRangeException();
		}

		public object NullSafeGet(DbDataReader dr, string[] names, ISessionImplementor session, object owner)
		{
			var value1 = (SinglePropertyStruct)PropertyTypes[0].NullSafeGet(dr, names[0], session, owner);
			var value2 = (SinglePropertyStruct)PropertyTypes[1].NullSafeGet(dr, names[1], session, owner);
			return new DoublePropertyStruct(value1, value2);
		}

		public void NullSafeSet(DbCommand cmd, object value, int index, bool[] settable, ISessionImplementor session)
		{
			var s = (DoublePropertyStruct)value;
			PropertyTypes[0].NullSafeSet(cmd, s.Value1, index, session);
			PropertyTypes[1].NullSafeSet(cmd, s.Value2, index + 1, session);
		}

		public object Replace(object original, object target, ISessionImplementor session, object owner) => original;

		public void SetPropertyValue(object component, int property, object value)
		{
			//var s = (DoublePropertyStruct) component;
			//switch (property)
			//{
			//	case 0:
			//		value.Value1;
			//	case 1:
			//		return value.Value2;
			//}
			throw new ArgumentOutOfRangeException();
		}
	}
}
