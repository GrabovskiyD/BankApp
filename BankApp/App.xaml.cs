﻿using BankApp.Model;
using BankApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Роль сотрудника банка /
        /// Bank employee role
        /// </summary>
        public static IEmployee Employee { get; set; }
    }
}
