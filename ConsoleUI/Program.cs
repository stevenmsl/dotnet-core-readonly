using System;
using System.Collections.Generic;

using DomainLogic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemRoot = new ItemAggregateRoot();

            IReadOnlyCollection<MutableItem> roMutables = itemRoot.MutableItems;

            foreach (var item in roMutables)
            {
                // each item is still mutable and can be mutated 
                // even through iterating a read-only collection 
                item.Name = "changed (IReadOnlyCollection) ";
            }

            log(itemRoot.MutableItems);

            var newMutables = new List<MutableItem>(roMutables);
            newMutables.Add(new MutableItem { Id = 3, Name = "Test3" });
            newMutables.ForEach(item =>
            {
                item.Name = "changed (new list (newMutables) created based on IReadOnlyCollection) ";
            });

            // The number of items in the mutable list still remans two, which means we can’t add any new entries 
            // to the mutable list. 
            // However you still can mutate item 1 and item 2 in the mutable list. 
            log(itemRoot.MutableItems);

            IReadOnlyCollection<ImmutableItem> roImmutables = itemRoot.ImmutableItems;

            // nothing you can do to mutate the items      
            foreach (var item in roImmutables)
            {
              
            }

            Console.ReadKey();
        }

        private static void log(IReadOnlyCollection<MutableItem> mutables)
        {
            Console.WriteLine($"List items in the mutables list (count: {mutables.Count}) ");

            foreach (var item in mutables)
            {
                Console.WriteLine($"Id:{item.Id}, Name:{item.Name}");
            }

        }
    }
}
