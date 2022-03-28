# The Complete WPF Tutorial
This project was built by following The Complete WPF Tutorial.
- Welcome to this WPF tutorial, currently consisting of 125 articles, where you'll learn to make your own applications using the WPF UI framework. If you're brand new to WPF, then we recommend that you start from the first chapter and then read your way through all of it.

### About WPF
##### What is WPF?
- WPF, which stands for Windows Presentation Foundation, is Microsoft's latest approach to a GUI framework, used with the .NET framework.
##### WPF vs. WinForms
- The single most important difference between WinForms and WPF is the fact that while WinForms is simply a layer on top of the standard Windows controls (e.g. a TextBox), WPF is built from scratch and doesn't rely on standard Windows controls in almost all situations. This might seem like a subtle difference, but it really isn't, which you will definitely notice if you have ever worked with a framework that depends on Win32/WinAPI.

### Getting Started
##### Visual Studio Community 
- WPF is, as already described, a combination of XAML (markup) and C#/VB.NET/any other .NET language. All of it can be edited in any text editor, even Notepad included in Windows, and then compiled from the command line. However, most developers prefer to use an IDE (Integrated Development Environment), since it makes everything, from writing code to designing the interface and compiling it all so much easier.
##### Hello, WPF! 
```
<Window x:Class="WpfApplication1.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    Title="MainWindow" Height="350" Width="525">
    <Grid>
        <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="72">
            Hello, WPF!
        </TextBlock>
    </Grid>
</Window>
```

### XAML
##### What is XAML?
- XAML, which stands for eXtensible Application Markup Language, is Microsoft's variant of XML for describing a GUI. In previous GUI frameworks, like WinForms, a GUI was created in the same language that you would use for interacting with the GUI, e.g. C# or VB.NET and usually maintained by the designer (e.g. Visual Studio), but with XAML, Microsoft is going another way. Much like with HTML, you are able to easily write and edit your GUI.
##### Basic XAML
- HTML is not case-sensitive, but XAML is, because the control name has to correspond to a type in the .NET framework. The same goes for attribute names, which corresponds to the properties of the control. Here's a button where we define a couple of properties by adding attributes to the tag:
##### Events in XAML
- Most modern UI frameworks are event driven and so is WPF. All of the controls, including the Window (which also inherits the Control class) exposes a range of events that you may subscribe to. You can subscribe to these events, which means that your application will be notified when they occur and you may react to that. There are many types of events, but some of the most commonly used are there to respond to the user's interaction with your application using the mouse or the keyboard. On most controls you will find events like KeyDown, KeyUp, MouseDown, MouseEnter, MouseLeave, MouseUp and several others.

### A WPF Application
1) A WPF Application - Introduction
2) The Window
3) Working with App.xaml
4) Command-line parameters in WPF
5) Resources
6) Handling exceptions in WPF
7) Application Culture / UICulture
![WPF](https://user-images.githubusercontent.com/57606580/160490005-fa19a057-2166-4b99-975b-1e9555db9dbb.PNG)

### Basic Controls
1) The TextBlock control - Inline formatting
2) The Label control
3) The TextBox control
4) The Button control
5) The CheckBox control
6) The RadioButton control
7) The PasswordBox control
8) The Image control

## Souces
- https://wpf-tutorial.com/

## C# Project by Lee McCormick
Learning C# is one of my goal in 2022. Enjoy learning it until I am a professional C# developer. This project was built by following the tutorial and source code online.
