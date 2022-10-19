using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TECHNICAL_ASSESSMENT.Models;
using TECHNICAL_ASSESSMENT.Models.Entity;

namespace TECHNICAL_ASSESSMENT.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult CreateUser()
        {
            return View("AdminPage");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddUser(User user)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.User.Add(user);
                    context.SaveChanges();

                    List<User> userDetails = context.User.ToList();
                    return View("ViewUserList", userDetails);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }


        }

        [Authorize(Roles = "Patient")]
        public ActionResult CreateAppointment()
        {
            try
            {
                List<User> userDetails = new List<User>();
                using (var context = new DBContext())
                {
                    userDetails = context.User.ToList();
                    List<string> myList = userDetails.Where(m => (int)m.RoleId == 2).Select(a => a.UserName).ToList();

                    IEnumerable<string> myEnumerable = myList.AsEnumerable();
                    ViewBag.Doctors = new SelectList(myEnumerable);

                    return View();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [Authorize(Roles = "Doctor,Patient")]
        public ActionResult ViewAppointment()
        {
            try
            {
                List<Appointment> appointmentList = new List<Appointment>();
                using (var context = new DBContext())
                {
                    appointmentList = context.Appointment.Where(m => m.DoctorName == User.Identity.Name).ToList();
                    return View("ViewAppointment", appointmentList);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

        }        

        [Authorize(Roles = "Doctor")]
        public ActionResult Status(int id, string status)
        {
            try
            {
                List<Appointment> appointmentList = new List<Appointment>();
                using (var context = new DBContext())
                {
                    Appointment appointment = context.Appointment.FirstOrDefault(m => m.AppointmentId == id);
                    if (appointment != null)
                    {
                        appointment.Status = status;
                        context.SaveChanges();
                        appointmentList = context.Appointment.Where(m => m.DoctorName == User.Identity.Name).ToList();
                    }
                    return View("ViewAppointment", appointmentList);

                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        [Authorize(Roles = "Patient")]
        public ActionResult AddAppointment(Appointment appointment)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Appointment.Add(appointment);
                    context.SaveChanges();
                }
                return RedirectToAction("CreateAppointment");
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        public ActionResult LoginUser(LoginUser login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBContext db = new DBContext())
                    {
                        //This is used for initial setup in database
                        db.User.ToList();

                        var obj = db.User.Where(a => a.UserName.Equals(login.UserName) && a.Password.Equals(login.Password)).FirstOrDefault();
                        var roleName = obj.RoleId.ToString();
                        if (obj != null)
                        {
                            Session["UserID"] = obj.UserId.ToString();
                            Session["UserName"] = obj.UserName.ToString();

                            FormsAuthentication.SetAuthCookie(login.UserName, false);
                        }

                        if (obj.RoleId == RoleValue.Admin)
                        {
                            return RedirectToAction("ViewUserList");
                        }
                        else if (obj.RoleId == RoleValue.Doctor)
                        {
                            return RedirectToAction("ViewAppointment");
                        }
                        else if (obj.RoleId == RoleValue.Patient)
                        {
                            return RedirectToAction("CreateAppointment");
                        }
                    }
                }
                return RedirectToAction("Login", "Home");
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewUserList()
        {
            try
            {
                List<User> userDetails = new List<User>();
                using (var context = new DBContext())
                {
                    userDetails = context.User.ToList();
                    return View("ViewUserList", userDetails);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        
    }
}