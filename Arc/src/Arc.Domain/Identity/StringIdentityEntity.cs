using System;

namespace Arc.Domain.Identity
{
	public class StringIdentityEntity : IEntity<string>, IVersioned
	{
		private int _transientHashCode;

		public StringIdentityEntity()
		{
		}

		public StringIdentityEntity(string identity)
		{
			Id = identity;
		}

		public virtual string Id { get; set; }

		public virtual bool IsTransient
		{
			get { return Id == null; }
		}

		public virtual int Version { get; protected set; }

		public override bool Equals(object obj)
		{
			return Equals(obj as IEntity<string>);
		}

		public override int GetHashCode()
		{
			if (!IsTransient) return Id.GetHashCode();

			if (_transientHashCode == 0)
			{
				_transientHashCode = base.GetHashCode();
			}
			return _transientHashCode;
		}

		public virtual bool Equals(IEntity<string> obj)
		{
			if (obj == null) return false;

			if (IsTransient) return ReferenceEquals(this, obj);

			var objType = obj.GetUnproxiedType();
			var type = GetUnproxiedType();

			return obj.Id == Id && objType == type;
		}

		public virtual Type GetUnproxiedType()
		{
			return GetType();
		}
	}
}