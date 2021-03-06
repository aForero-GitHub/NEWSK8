﻿namespace IUForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance; 

        public LoginViewModel Login { get; set; }

        public PostsViewModel Posts { get; set; }

        public MainViewModel()
        {
            instance = this;

            //this.Login = new LoginViewModel(); 
        }

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
