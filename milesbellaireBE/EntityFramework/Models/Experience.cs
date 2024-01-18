using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MbCore.EntityFramework.Models;

namespace MbCore.EntityFramework.Models
{
    public abstract class Experience : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Priority { get; set; }
        public List<Tag> Tags { get; set; } = new();
    }
}

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.UseTptMappingStrategy();

        builder.HasMany(experience => experience.Tags)
            .WithOne(tag => tag.Experience);
    }
}