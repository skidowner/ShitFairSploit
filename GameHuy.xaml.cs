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
	// Token: 0x02000007 RID: 7
	public partial class GameHuy : Window
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00003B69 File Offset: 0x00001D69
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00003B71 File Offset: 0x00001D71
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x0600005C RID: 92 RVA: 0x00003B7C File Offset: 0x00001D7C
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

		// Token: 0x0600005D RID: 93 RVA: 0x00003C14 File Offset: 0x00001E14
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

		// Token: 0x0600005E RID: 94 RVA: 0x00003CAC File Offset: 0x00001EAC
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

		// Token: 0x0600005F RID: 95 RVA: 0x00003D30 File Offset: 0x00001F30
		public GameHuy()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003D92 File Offset: 0x00001F92
		private void Minimaze_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003D9C File Offset: 0x00001F9C
		[DebuggerStepThrough]
		private void Griddd_Loaded(object sender, RoutedEventArgs e)
		{
			GameHuy.<Griddd_Loaded>d__12 <Griddd_Loaded>d__ = new GameHuy.<Griddd_Loaded>d__12();
			<Griddd_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Griddd_Loaded>d__.<>4__this = this;
			<Griddd_Loaded>d__.sender = sender;
			<Griddd_Loaded>d__.e = e;
			<Griddd_Loaded>d__.<>1__state = -1;
			<Griddd_Loaded>d__.<>t__builder.Start<GameHuy.<Griddd_Loaded>d__12>(ref <Griddd_Loaded>d__);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003DE4 File Offset: 0x00001FE4
		private void Griddd_MouseDown(object sender, MouseButtonEventArgs e)
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

		// Token: 0x06000063 RID: 99 RVA: 0x00003E20 File Offset: 0x00002020
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

		// Token: 0x04000039 RID: 57
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x0400003A RID: 58
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x0400003B RID: 59
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
