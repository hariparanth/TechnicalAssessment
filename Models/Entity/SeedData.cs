using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TECHNICAL_ASSESSMENT.Models.Entity
{
    public class SeedData : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            IList<Roles> roles = new List<Roles>();
            roles.Add(new Roles() { RoleName = "Admin", RoleId = 1 });
            roles.Add(new Roles() { RoleName = "Doctor", RoleId = 2 });
            roles.Add(new Roles() { RoleName = "Patient", RoleId = 3 });
            context.Roles.AddRange(roles);


            IList<User> users = new List<User>();

            users.Add(new User()
            {
                RoleId = RoleValue.Admin,
                UserName = "AdminOne",
                FirstName = "AdminOneFirstName",
                LastName = "AdminOneLastName",
                Email = "AdminOne@gmail.com",
                Password = "Test@1234",
                DOB = DateTime.Now.AddYears(-10),
                MobileNo = 9087654321
            });

            users.Add(new User()
            {
                RoleId = RoleValue.Doctor,
                UserName = "DoctorOne",
                FirstName = "DoctorOneFirstName",
                LastName = "DoctorOneLastName",
                Email = "DoctorOne@gmail.com",
                Password = "Test@1234",
                DOB = DateTime.Now.AddYears(-10),
                MobileNo = 9651043287
            });

            users.Add(new User()
            {
                RoleId = RoleValue.Doctor,
                UserName = "DoctorTwo",
                FirstName = "DoctorTwoFirstName",
                LastName = "DoctorTwoLastName",
                Email = "DoctorTwo@gmail.com",
                Password = "Test@1234",
                DOB = DateTime.Now.AddYears(-10),
                MobileNo = 9043287651
            });

            users.Add(new User()
            {
                RoleId = RoleValue.Patient,
                UserName = "PatientOne",
                FirstName = "PatientOneFirstName",
                LastName = "PatientOneLastName",
                Email = "PatientOne@gmail.com",
                Password = "Test@1234",
                DOB = DateTime.Now.AddYears(-10),
                MobileNo = 9876540321
            });
            context.User.AddRange(users);

            base.Seed(context);
        }
    }
}