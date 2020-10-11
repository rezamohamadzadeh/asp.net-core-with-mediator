using System;

namespace MediatorApiExample.Core.Entities
{
    public class FriendItem : IEntity
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool Liked { get; private set; }

        public FriendItem(Guid id, string name, bool liked)
        {
            Id = id;
            Name = name;
            Liked = liked;
        }

        public void ToggleLike()
        {
            Liked = !Liked;
        }
    }
}