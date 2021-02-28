using Core.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Ürünler listelendi";
        public static string CarImagesCountExceed = "Car images not above 5";
        public static string ImageAdded = "Car Image Added";
        public static string ImageUpdated = "Car Image Updated";
        public static string AuthorizationDenied = "You dont have authorization";
        public static string AccessTokenCreated = "Token is created";
        public static string UserAlreadyExists = "This user already exist";
        public static string InValidUser = "Invalid user";
        public static string SuccessfullyRegister = "Registeration is successfull";
        public static string PasswordError = "Password wrong";
        public static string SuccessfullyLogin = "Successfully login";
        public static string ValidUser = "Valid user";
    }
}
