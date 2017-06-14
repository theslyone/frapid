using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Frapid.Configuration.Events.Interfaces
{
    public interface IEventManager
    {
        void Publish<T>(T eventMessage) where T : class;
        void Subscribe<T>(Assembly assembly, Func<T, Task> action) where T : class;
    }

    public static class IEventManagerExtensions
    {
        public static void EntityInserted<T>(this IEventManager eventPublisher, T entity) where T : class
        {
            eventPublisher.Publish(new EntityInserted<T>(entity));
        }

        public static void EntityUpdated<T>(this IEventManager eventPublisher, T entity) where T : class
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity));
        }

        public static void EntityDeleted<T>(this IEventManager eventPublisher, T entity) where T : class
        {
            eventPublisher.Publish(new EntityDeleted<T>(entity));
        }
    }

    public class EntityDeleted<T> where T : class
    {
        public T Entity { get; set; }

        public EntityDeleted(T entity)
        {
            this.Entity = entity;
        }
    }

    public class EntityUpdated<T> where T : class
    {
        public T Entity { get; set; }

        public EntityUpdated(T entity)
        {
            this.Entity = entity;
        }
    }

    public class EntityInserted<T> where T : class
    {
        public T Entity { get; set; }

        public EntityInserted(T entity)
        {
            this.Entity = entity;
        }
    }
}
