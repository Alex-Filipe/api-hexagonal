using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#nullable enable
namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model
{
    [ExcludeFromCodeCoverage]
    public class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();

        public DateTime? Updated { get; set; }

        public DateTime? Excluded { get; set; }

        public static bool operator ==(Entity? left, Entity? right)
        {
            return object.Equals((object) left, (object) right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !object.Equals((object) left, (object) right);
        }

        public override bool Equals(object? obj)
        {
            Entity entity = obj as Entity;
            if ((object) entity == null)
                return false;
            if ((object) this == (object) entity)
                return true;
            return this.GetType() == entity.GetType() && entity.Id.Equals(this.Id);
        }

        public override int GetHashCode() => this.GetType().GetHashCode() * 907 + this.Id.GetHashCode();

        public override string ToString() => this.GetType().Name + " [Id=" + this.Id.ToString() + "]";
    }
}