namespace Arc.Domain.Identity
{
    public interface IActiveRecord : IEntity, ISaveable, IDeletable { }

    public interface IActiveRecord<TIdentity> : IEntity<TIdentity>, IActiveRecord { }
}