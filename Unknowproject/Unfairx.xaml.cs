using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using KrnlAPI;

namespace Unknowproject
{
	// Token: 0x02000004 RID: 4
	public partial class Unfairx : Window
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003232 File Offset: 0x00001432
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000323A File Offset: 0x0000143A
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x0600003E RID: 62 RVA: 0x00003244 File Offset: 0x00001444
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

		// Token: 0x0600003F RID: 63 RVA: 0x000032DC File Offset: 0x000014DC
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

		// Token: 0x06000040 RID: 64 RVA: 0x00003374 File Offset: 0x00001574
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

		// Token: 0x06000041 RID: 65 RVA: 0x000033F8 File Offset: 0x000015F8
		public Unfairx()
		{
			this.InitializeComponent();
			MainAPI.Loaded();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000346C File Offset: 0x0000166C
		[DebuggerStepThrough]
		private void Gridd_Loaded(object sender, RoutedEventArgs e)
		{
			Unfairx.<Gridd_Loaded>d__12 <Gridd_Loaded>d__ = new Unfairx.<Gridd_Loaded>d__12();
			<Gridd_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Gridd_Loaded>d__.<>4__this = this;
			<Gridd_Loaded>d__.sender = sender;
			<Gridd_Loaded>d__.e = e;
			<Gridd_Loaded>d__.<>1__state = -1;
			<Gridd_Loaded>d__.<>t__builder.Start<Unfairx.<Gridd_Loaded>d__12>(ref <Gridd_Loaded>d__);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000034B4 File Offset: 0x000016B4
		private void Gridd_MouseDown(object sender, MouseButtonEventArgs e)
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

		// Token: 0x06000044 RID: 68 RVA: 0x000034F0 File Offset: 0x000016F0
		private void Minimaze_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000034F3 File Offset: 0x000016F3
		private void Minimaze_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003500 File Offset: 0x00001700
		private void ExecuteOwl_Click_1(object sender, RoutedEventArgs e)
		{
			WebClient webClient = new WebClient();
			string script = webClient.DownloadString("https://raw.githubusercontent.com/ZinityDrops/OwlHubLink/master/OwlHubBack.lua");
			MainAPI.Execute(script);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003527 File Offset: 0x00001727
		private void Ma_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000352C File Offset: 0x0000172C
		private void ExecuteDark_Click(object sender, RoutedEventArgs e)
		{
			WebClient webClient = new WebClient();
			string script = webClient.DownloadString("https://raw.githubusercontent.com/RandomAdamYT/DarkHub/master/Init");
			MainAPI.Execute(script);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003554 File Offset: 0x00001754
		private void ExecuteIY_Click(object sender, RoutedEventArgs e)
		{
			WebClient webClient = new WebClient();
			string script = webClient.DownloadString("https://raw.githubusercontent.com/EdgeIY/infiniteyield/master/source");
			MainAPI.Execute(script);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000357C File Offset: 0x0000177C
		private void Minizame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

		// Token: 0x04000020 RID: 32
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000021 RID: 33
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000022 RID: 34
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		// Token: 0x04000024 RID: 36
		private UnfairSploit un = new UnfairSploit();
	}
}
