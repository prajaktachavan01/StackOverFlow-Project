﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverFlowProject.Repositories
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string email, string password);
        List<User> GetUsersByEmail(string email);
        List<User> GetUsersByUserID(int UserID);
        int GetLatestUserID();

    }
    public class UserRepository : IUsersRepository
    {
        StackOverFlowDatabaseDbContext db;

        public UserRepository()
        {
            db = new StackOverFlowDatabaseDbContext();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if(us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int uid)
        {
            User us = db.Users.Where(temp => temp.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
        }


        public List<User> GetUsers()
        {
            List<User> us = db.Users.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.Name).ToList();
            return us;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string passwordHash)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash == passwordHash).ToList();
            return us;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email).ToList();
            return us;
        }

        public List<User> GetUsersByUserID(int UserID)
        {
            List<User> us = db.Users.Where(temp =>temp.UserID == UserID).ToList();
            return us;
        }

        public int GetLatestUserID()
        {
            int uid = db.Users.Select(temp => temp.UserID).Max();
            return uid;
        }
    }
}