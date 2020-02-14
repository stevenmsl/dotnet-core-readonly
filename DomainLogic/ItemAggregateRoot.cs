using System.Collections.Generic;
namespace DomainLogic
{
    // To achieve truly read-only (immutable) protection
    // 1. Return read-only collection so no new entries can be added, 
    //    or existing entries removed
    // 2. Each item in the collection needs to be immutable in itself
    public class ItemAggregateRoot
    {
        private List<MutableItem> _mutables = new List<MutableItem>()
            {
                new MutableItem { Id = 1, Name = "Test1"},
                new MutableItem { Id = 2, Name = "Test2"}
            };

        private List<ImmutableItem> _immutables = new List<ImmutableItem>()
            {
                new ImmutableItem ( 1, "Test1"),
                new ImmutableItem ( 2, "Test2")
            };

        // Collection itself is read-only; you can’t add new entries to it for example. 
        // Each individual item still can be mutated by the clients though.
        public IReadOnlyCollection<MutableItem> MutableItems => _mutables.AsReadOnly();

        // Everything is read-only
        public IReadOnlyCollection<ImmutableItem> ImmutableItems => _immutables.AsReadOnly();
    }
}
