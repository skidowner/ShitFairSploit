using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Unknowproject
{
	// Token: 0x02000006 RID: 6
	public partial class MainWindow : Window
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00003807 File Offset: 0x00001A07
		// (set) Token: 0x06000051 RID: 81 RVA: 0x0000380F File Offset: 0x00001A0F
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x06000052 RID: 82 RVA: 0x00003818 File Offset: 0x00001A18
		public void Fade(DependencyObject Object)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				From = new double?(0.0),
				To = new double?(1.0),
				Duration = new Duration(this.duration)
			};
			Storyboard.SetTarget(doubleAnimation, Object);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[]
			{
				1
			}));
			this.StoryBoard.Children.Add(doubleAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000038B0 File Offset: 0x00001AB0
		public void FadeOut(DependencyObject Object)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				From = new double?(1.0),
				To = new double?(0.0),
				Duration = new Duration(this.duration)
			};
			Storyboard.SetTarget(doubleAnimation, Object);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[]
			{
				1
			}));
			this.StoryBoard.Children.Add(doubleAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003948 File Offset: 0x00001B48
		public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
		{
			ThicknessAnimation thicknessAnimation = new ThicknessAnimation
			{
				From = new Thickness?(Get),
				To = new Thickness?(Set),
				Duration = this.duration2,
				EasingFunction = this.Smooth
			};
			Storyboard.SetTarget(thicknessAnimation, Object);
			Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
			this.StoryBoard.Children.Add(thicknessAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000039CC File Offset: 0x00001BCC
		public MainWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003A30 File Offset: 0x00001C30
		[DebuggerStepThrough]
		private void Logo_Loaded(object sender, RoutedEventArgs e)
		{
			MainWindow.<Logo_Loaded>d__11 <Logo_Loaded>d__ = new MainWindow.<Logo_Loaded>d__11();
			<Logo_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Logo_Loaded>d__.<>4__this = this;
			<Logo_Loaded>d__.sender = sender;
			<Logo_Loaded>d__.e = e;
			<Logo_Loaded>d__.<>1__state = -1;
			<Logo_Loaded>d__.<>t__builder.Start<MainWindow.<Logo_Loaded>d__11>(ref <Logo_Loaded>d__);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003A78 File Offset: 0x00001C78
		[DebuggerStepThrough]
		private void L_Loaded(object sender, RoutedEventArgs e)
		{
			MainWindow.<L_Loaded>d__12 <L_Loaded>d__ = new MainWindow.<L_Loaded>d__12();
			<L_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<L_Loaded>d__.<>4__this = this;
			<L_Loaded>d__.sender = sender;
			<L_Loaded>d__.e = e;
			<L_Loaded>d__.<>1__state = -1;
			<L_Loaded>d__.<>t__builder.Start<MainWindow.<L_Loaded>d__12>(ref <L_Loaded>d__);
		}

		// Token: 0x04000032 RID: 50
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000033 RID: 51
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000034 RID: 52
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
