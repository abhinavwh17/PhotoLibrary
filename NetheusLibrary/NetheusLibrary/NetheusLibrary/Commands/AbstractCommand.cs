﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NetheusLibrary.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        private readonly Action<object> _executeCallback;
        private readonly Func<object, bool> _canExecuteCallback;

        public event EventHandler CanExecuteChanged;

        protected AbstractCommand(Action<object> executeCallback)
        {
            _executeCallback = executeCallback;
            _canExecuteCallback = o => true;
        }

        protected AbstractCommand(Action<object> executeCallback, Func<object, bool> canExecuteCallback)
        {
            _executeCallback = executeCallback;
            _canExecuteCallback = canExecuteCallback;
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteCallback(parameter);
        }

        public void Execute(object parameter)
        {
            _executeCallback(parameter);
        }
    }
}
