using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginAuth.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LoginAuth.DAL
{
    public class AttendanceDB : DbContext
    {
        public DbSet<FileUpload> FileUploads { get; set; }
    }
 
}
