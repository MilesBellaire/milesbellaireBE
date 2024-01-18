using MbCore.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MbCore.EntityFramework;
public class DatabaseContext : DbContext
{
    public DbSet<WorkExperience> WorkExperience { get; set; }
    public DbSet<PersonalProject> PersonalProject { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Tag> Tag { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
}