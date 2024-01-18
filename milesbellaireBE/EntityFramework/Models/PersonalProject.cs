using MbCore.EntityFramework.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MbCore.EntityFramework.Models
{
    public class PersonalProject : Experience
    {

    }
}

public class PersonalProjectConfiguration : IEntityTypeConfiguration<PersonalProject>
{
    public void Configure(EntityTypeBuilder<PersonalProject> builder)
    {

    }
}