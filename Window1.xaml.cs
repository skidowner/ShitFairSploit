using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UnfairSploit
{
	// Token: 0x02000009 RID: 9
	public partial class Window1 : Window
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003F85 File Offset: 0x00002185
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00003F8D File Offset: 0x0000218D
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x0600006A RID: 106 RVA: 0x00003F98 File Offset: 0x00002198
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

		// Token: 0x0600006B RID: 107 RVA: 0x00004030 File Offset: 0x00002230
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

		// Token: 0x0600006C RID: 108 RVA: 0x000040C8 File Offset: 0x000022C8
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

		// Token: 0x0600006D RID: 109 RVA: 0x0000414C File Offset: 0x0000234C
		public Window1()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000041AE File Offset: 0x000023AE
		private void Gridz_MouseMove(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000041B4 File Offset: 0x000023B4
		[DebuggerStepThrough]
		private void Gridz_Loaded(object sender, RoutedEventArgs e)
		{
			Window1.<Gridz_Loaded>d__12 <Gridz_Loaded>d__ = new Window1.<Gridz_Loaded>d__12();
			<Gridz_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Gridz_Loaded>d__.<>4__this = this;
			<Gridz_Loaded>d__.sender = sender;
			<Gridz_Loaded>d__.e = e;
			<Gridz_Loaded>d__.<>1__state = -1;
			<Gridz_Loaded>d__.<>t__builder.Start<Window1.<Gridz_Loaded>d__12>(ref <Gridz_Loaded>d__);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000041FB File Offset: 0x000023FB
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004205 File Offset: 0x00002405
		private void Minimaze_Click(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004210 File Offset: 0x00002410
		private void Gridz_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = e.ChangedButton == MouseButton.Left;
			if (flag)
			{
				try
				{
					base.DragMove();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000424C File Offset: 0x0000244C
		private void closeapp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004288 File Offset: 0x00002488
		private void Minizame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				base.WindowState = WindowState.Minimized;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x04000044 RID: 68
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000045 RID: 69
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000046 RID: 70
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
