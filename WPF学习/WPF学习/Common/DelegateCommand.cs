using System;
using System.Windows.Input;

namespace WPF学习.Common
{
    public class DelegateCommand : ICommand
    {

        #region 构造函数
        public DelegateCommand(Action<object> execute) : this(execute, null) { }
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                return;

            executeAction = execute;
            canExecuteFunc = canExecute;
        }
        #endregion

        #region Command的操作和权限
        private Action<object> executeAction;
        private Func<object, bool> canExecuteFunc;


        public event EventHandler CanExecuteChanged;

        private bool _canExecuteFlag = true;
        public bool CanExecuteFlag
        {
            get { return _canExecuteFlag; }
            set
            {
                if (_canExecuteFlag != value)
                {
                    _canExecuteFlag = value;
                    CanExecuteChanged?.Invoke(this, new EventArgs()); //状态变化发送通知
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            // 简化表达式  canExecuteFunc为null返回true，否则返回canExecuteFunc(parameter)
            CanExecuteFlag = canExecuteFunc == null || canExecuteFunc(parameter);
            return CanExecuteFlag;
        }

        public void Execute(object parameter)
        {
            executeAction?.Invoke(parameter);
        }



        #endregion
    }
}
