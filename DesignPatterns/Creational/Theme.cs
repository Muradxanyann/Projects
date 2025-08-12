/* Task 2:
You are building a GUI library that supports two styles: LightTheme and DarkTheme.
Each theme must provide its own version of Button, TextBox, and CheckBox. */
using System.Runtime.CompilerServices;

namespace Task2
{
    interface IButton
    {
        string Render();
    }

    interface ITextBox
    {
        string Render();
    }

    interface ICheckBox
    {
        string Render();
    }

    class LightButton : IButton
    {
        public string Render()
        {
            return "Rendering a light button.";
        }
    }

    class LightTextBox : ITextBox
    {
        public string Render()
        {
            return "Rendering a light text box.";
        }
    }

    class LightCheckBox : ICheckBox
    {
        public string Render()
        {
            return "Rendering a light check box.";
        }
    }

    class DarkButton : IButton
    {
        public string Render()
        {
            return "Rendering a dark button.";
        }
    }

    class DarkTextBox : ITextBox
    {
        
        public string Render()
        {
            return "Rendering a dark text box.";
        }
    }

    class DarkCheckBox : ICheckBox
    {
        public string Render()
        {
            return "Rendering a dark check box.";
        }
    }

    interface IThemeFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
        ICheckBox CreateCheckBox();
    }

    class LightThemeFactory : IThemeFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ITextBox CreateTextBox()
        {
            return new LightTextBox();
        }

        public ICheckBox CreateCheckBox()
        {
            return new LightCheckBox();
        }
    }

    class DarkThemeFactory : IThemeFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }
        public ITextBox CreateTextBox()
        {
            return new DarkTextBox();
        }

        public ICheckBox CreateCheckBox()
        {
            return new DarkCheckBox();
        }
    }

    class UIController
    {
        private readonly IButton _button;

        private readonly ITextBox _textBox;

        private readonly ICheckBox _checkBox;

        public UIController(IThemeFactory themeFactory)
        {
            
            _button = themeFactory.CreateButton();
            _textBox = themeFactory.CreateTextBox();
            _checkBox = themeFactory.CreateCheckBox();
        }

        public void RenderUI()
        {
            Console.WriteLine(_button.Render());
            Console.WriteLine(_textBox.Render());
            Console.WriteLine(_checkBox.Render());
        }
    }

    
}
