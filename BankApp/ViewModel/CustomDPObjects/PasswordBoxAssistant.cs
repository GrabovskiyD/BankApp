using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankApp.ViewModel.CustomDPObjects
{
    /*
        Реализация класса взята из блога  http://blog.functionalfun.net/2008/06/wpf-passwordbox-and-data-binding.html
        The class implementation is taken from the blog http://blog.functionalfun.net/2008/06/wpf-passwordbox-and-data-binding.html
     */
    /// <summary>
    /// Класс, позволяющий создать безопасную(?) привязку для PasswordBox/
    /// The class that allows to create a secure(?) binding for a PasswordBox
    /// </summary>
    public static class PasswordBoxAssistant
    {
        /// <summary>
        /// Свойство, к которому осуществляется привязка Password из ViewModel
        /// The property to which is bound the Password from the ViewModel 
        /// </summary>
        public static readonly DependencyProperty BoundPassword = 
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));
        /// <summary>
        /// Включение и выключение "прослушивания" изменений в PasswordBox
        /// Enabling and disabling "listening" for changes in a PasswordBox
        /// </summary>
        public static readonly DependencyProperty BindPassword =
            DependencyProperty.RegisterAttached("BindPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false, OnBindPasswordChanged));
        /// <summary>
        /// Свойство помогает не допустить возникновение рекурсивных замыканий при привязке данных
        /// This property helps to prevent recursive closures when binding data
        /// </summary>
        private static readonly DependencyProperty UpdatingPassword = DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false));
        /// <summary>
        /// Вызывается при изменении привязанного свойства Password/
        /// Called when bound password changed
        /// </summary>
        /// <param name="d">Вызывающий объект/The caller item</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data/Параметр, содержащий данные о событии</param>
        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = d as PasswordBox;
            if(d == null || !GetBindPassword(d))
            {
                return;
            }
            box.PasswordChanged -= HandlePasswordChanged;
            string newPassword = (string)e.NewValue;
            if (!GetUpdatingPassword(box))
            {
                box.Password = newPassword;
            }
            box.PasswordChanged += HandlePasswordChanged;
        }
        /// <summary>
        /// Вызывается при включении/выключении "прослушивания" изменений в PasswordBox/
        /// Called when enabling/disabling "listening" for changes in a PasswordBox
        /// </summary>
        /// <param name="d">Вызывающий объект/The caller item</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data/Параметр, содержащий данные о событии</param>
        private static void OnBindPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = d as PasswordBox;
            if(box == null)
            {
                return;
            }
            bool wasBound = (bool)(e.OldValue);
            bool needToBind = (bool)(e.NewValue);
            if (wasBound)
            {
                box.PasswordChanged -= HandlePasswordChanged;
            }
            if (needToBind)
            {
                box.PasswordChanged += HandlePasswordChanged;
            }
        }
        /// <summary>
        /// Обработчик события изменения пароля/Handles the password changed event
        /// </summary>
        /// <param name="sender">Вызывающий объект/Caller item</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data/Состояние, содержащее данные о событии</param>
        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;
            SetUpdatingPassword(box, true);
            SetBoundPassword(box, box.Password);
            SetUpdatingPassword(box, false);
        }
        public static void SetBindPassword(DependencyObject d, bool value)
        {
            d.SetValue(BindPassword, value);
        }
        public static bool GetBindPassword(DependencyObject d)
        {
            return (bool)d.GetValue(BindPassword);
        }
        public static string GetBoundPassword(DependencyObject d)
        {
            return (string)d.GetValue(BoundPassword);
        }
        public static void SetBoundPassword(DependencyObject d, string value)
        {
            d.SetValue(BoundPassword, value);
        }
        private static bool GetUpdatingPassword(DependencyObject d)
        {
            return (bool)d.GetValue(UpdatingPassword);
        }
        private static void SetUpdatingPassword(DependencyObject d, bool value)
        {
            d.SetValue(UpdatingPassword, value);
        }
    }
}
