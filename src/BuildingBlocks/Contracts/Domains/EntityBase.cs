using Contracts.Domains.Interfaces;
#nullable disable
namespace Contracts.Domains
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
