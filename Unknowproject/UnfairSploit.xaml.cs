using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using KrnlAPI;
using Microsoft.Win32;
using UnfairSploit;

namespace Unknowproject
{
	// Token: 0x02000003 RID: 3
	public partial class UnfairSploit : Window
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000208D File Offset: 0x0000028D
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002095 File Offset: 0x00000295
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x06000004 RID: 4 RVA: 0x000020A0 File Offset: 0x000002A0
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

		// Token: 0x06000005 RID: 5 RVA: 0x00002138 File Offset: 0x00000338
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

		// Token: 0x06000006 RID: 6 RVA: 0x000021D0 File Offset: 0x000003D0
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

		// Token: 0x06000007 RID: 7 RVA: 0x00002254 File Offset: 0x00000454
		public UnfairSploit()
		{
			this.InitializeComponent();
			Stream stream = File.OpenRead(Environment.CurrentDirectory + "\\lua\\Lua.xshd");
			XmlTextReader xmlTextReader = new XmlTextReader(stream);
			this.AvalonEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
			xmlTextReader.Close();
			stream.Close();
			this.EditTabs.Loaded += delegate(object source, RoutedEventArgs e)
			{
				this.EditTabs.GetTemplateItem("AddTabButton").Click += delegate(object s, RoutedEventArgs f)
				{
					this.MakeTab("", "New Tab");
				};
				TabItem tabItem = this.EditTabs.SelectedItem as TabItem;
				tabItem.GetTemplateItem("CloseButton").Visibility = Visibility.Hidden;
				tabItem.GetTemplateItem("CloseButton").Width = 0.0;
				tabItem.Header = "Main Tab";
				this.tabScroller = this.EditTabs.GetTemplateItem("TabScrollViewer");
			};
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000230F File Offset: 0x0000050F
		private void Main_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002312 File Offset: 0x00000512
		private void Main_MouseDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002315 File Offset: 0x00000515
		private void Button_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002318 File Offset: 0x00000518
		private void Inject_Click(object sender, RoutedEventArgs e)
		{
			MainAPI.Inject();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002324 File Offset: 0x00000524
		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
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

		// Token: 0x0600000D RID: 13 RVA: 0x00002360 File Offset: 0x00000560
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000236A File Offset: 0x0000056A
		private void Minimaze_Click(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002375 File Offset: 0x00000575
		private void Execute_Click(object sender, RoutedEventArgs e)
		{
			MainAPI.Execute(this.GetCurrent().Text);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002389 File Offset: 0x00000589
		private void AvalonEditor_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000238C File Offset: 0x0000058C
		private void List_Loaded(object sender, RoutedEventArgs e)
		{
			bool flag = this.List.SelectedIndex != -1;
			bool flag2 = flag;
			if (flag2)
			{
				this.GetCurrent().Text = File.ReadAllText("scripts\\" + this.List.SelectedItem.ToString());
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023E0 File Offset: 0x000005E0
		private void Gridl_Loaded(object sender, RoutedEventArgs e)
		{
			this.List.Items.Clear();
			foreach (FileInfo fileInfo in new DirectoryInfo("./scripts").GetFiles("*.txt"))
			{
				this.List.Items.Add(fileInfo.Name);
			}
			foreach (FileInfo fileInfo2 in new DirectoryInfo("./scripts").GetFiles("*.lua"))
			{
				this.List.Items.Add(fileInfo2.Name);
			}
			FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002493 File Offset: 0x00000693
		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			this.GetCurrent().Text = "";
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000024A8 File Offset: 0x000006A8
		private void Open_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			bool flag3 = flag.GetValueOrDefault() == flag2 & flag != null;
			if (flag3)
			{
				openFileDialog.Title = "OPEN";
				this.GetCurrent().Text = File.ReadAllText(openFileDialog.FileName);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002500 File Offset: 0x00000700
		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			bool? flag = saveFileDialog.ShowDialog();
			bool flag2 = true;
			bool flag3 = flag.GetValueOrDefault() == flag2 & flag != null;
			if (flag3)
			{
				using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
				{
					using (StreamWriter streamWriter = new StreamWriter(stream))
					{
						streamWriter.Write(this.GetCurrent().Text);
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000259C File Offset: 0x0000079C
		private void Search_TextChanged(object sender, TextChangedEventArgs e)
		{
			ICollectionView defaultView = CollectionViewSource.GetDefaultView(this.List.Items);
			bool flag = defaultView != null;
			if (flag)
			{
				defaultView.Filter = ((object o) => o.ToString().ToLower().Contains(this.Search.Text.ToLower()));
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000025D8 File Offset: 0x000007D8
		private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.List.SelectedIndex != -1;
			bool flag2 = flag;
			if (flag2)
			{
				this.GetCurrent().Text = File.ReadAllText("scripts\\" + this.List.SelectedItem.ToString());
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000262C File Offset: 0x0000082C
		[DebuggerStepThrough]
		private void Setting_Click(object sender, RoutedEventArgs e)
		{
			UnfairSploit.<Setting_Click>d__27 <Setting_Click>d__ = new UnfairSploit.<Setting_Click>d__27();
			<Setting_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Setting_Click>d__.<>4__this = this;
			<Setting_Click>d__.sender = sender;
			<Setting_Click>d__.e = e;
			<Setting_Click>d__.<>1__state = -1;
			<Setting_Click>d__.<>t__builder.Start<UnfairSploit.<Setting_Click>d__27>(ref <Setting_Click>d__);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002674 File Offset: 0x00000874
		private void gamehum_Click(object sender, RoutedEventArgs e)
		{
			Unfairx unfairx = new Unfairx();
			unfairx.Show();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000268F File Offset: 0x0000088F
		private void Clear_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002692 File Offset: 0x00000892
		private void Execute_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002695 File Offset: 0x00000895
		private void Open_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002698 File Offset: 0x00000898
		private void Save_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000269B File Offset: 0x0000089B
		private void Inject_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000269E File Offset: 0x0000089E
		private void Exit_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000026A1 File Offset: 0x000008A1
		private void gamehum_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026A4 File Offset: 0x000008A4
		private void Setting_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000026A7 File Offset: 0x000008A7
		private void Minimaze_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026AA File Offset: 0x000008AA
		private void ScrollTabs(object sender, MouseWheelEventArgs e)
		{
			this.tabScroller.ScrollToHorizontalOffset(this.tabScroller.HorizontalOffset + (double)(e.Delta / 10));
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026D0 File Offset: 0x000008D0
		private void MoveTab(object sender, MouseEventArgs e)
		{
			TabItem tabItem = e.Source as TabItem;
			bool flag = tabItem == null;
			if (!flag)
			{
				bool flag2 = Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed;
				if (flag2)
				{
					bool flag3 = VisualTreeHelper.HitTest(tabItem, Mouse.GetPosition(tabItem)).VisualHit is Button;
					if (!flag3)
					{
						DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.Move);
					}
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002734 File Offset: 0x00000934
		public TextEditor GetCurrent()
		{
			bool flag = this.EditTabs.Items.Count == 0;
			TextEditor result;
			if (flag)
			{
				result = this.AvalonEditor;
			}
			else
			{
				result = (this.current = (this.EditTabs.SelectedContent as TextEditor));
			}
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002784 File Offset: 0x00000984
		public TextEditor MakeEditor()
		{
			TextEditor textEditor = new TextEditor
			{
				ShowLineNumbers = true,
				Background = new SolidColorBrush(Color.FromRgb(24, 24, 24)),
				Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue)),
				LineNumbersForeground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue)),
				Margin = new Thickness(-2.0, -2.0, -2.0, -2.0),
				FontFamily = new FontFamily("Consolas"),
				Style = (base.TryFindResource("TextEditorStyle1") as Style),
				HorizontalScrollBarVisibility = ScrollBarVisibility.Visible,
				VerticalScrollBarVisibility = ScrollBarVisibility.Visible
			};
			textEditor.Options.EnableEmailHyperlinks = false;
			textEditor.Options.EnableHyperlinks = false;
			textEditor.Options.AllowScrollBelowDocument = true;
			Stream stream = File.OpenRead(Environment.CurrentDirectory + "\\lua\\lua.xshd");
			XmlTextReader xmlTextReader = new XmlTextReader(stream);
			textEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
			xmlTextReader.Close();
			stream.Close();
			return textEditor;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000028CC File Offset: 0x00000ACC
		public TabItem MakeTab(string text = "", string title = "Tab")
		{
			title = (title ?? "");
			bool loaded = false;
			TextEditor textEditor = this.MakeEditor();
			textEditor.Text = text;
			TabItem tab = new TabItem
			{
				Content = textEditor,
				Style = (base.TryFindResource("Tab") as Style),
				AllowDrop = true,
				Header = title
			};
			tab.MouseWheel += this.ScrollTabs;
			tab.Loaded += delegate(object source, RoutedEventArgs e)
			{
				bool loaded = loaded;
				if (!loaded)
				{
					this.tabScroller.ScrollToRightEnd();
					loaded = true;
				}
			};
			tab.MouseDown += delegate(object sender, MouseButtonEventArgs e)
			{
				bool flag = e.OriginalSource is Border;
				if (flag)
				{
					bool flag2 = e.MiddleButton == MouseButtonState.Pressed;
					if (flag2)
					{
						this.EditTabs.Items.Remove(tab);
					}
				}
			};
			tab.Loaded += delegate(object s, RoutedEventArgs e)
			{
				tab.GetTemplateItem("CloseButton").Click += delegate(object r, RoutedEventArgs f)
				{
					this.EditTabs.Items.Remove(tab);
				};
				this.tabScroller.ScrollToRightEnd();
				loaded = true;
			};
			tab.MouseMove += this.MoveTab;
			tab.Drop += this.DropTab;
			this.EditTabs.SelectedIndex = this.EditTabs.Items.Add(tab);
			return tab;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A05 File Offset: 0x00000C05
		private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.DragMove();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A0F File Offset: 0x00000C0F
		private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A19 File Offset: 0x00000C19
		private void EditTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A1C File Offset: 0x00000C1C
		private void DropTab(object sender, DragEventArgs e)
		{
			TabItem tabItem = e.Source as TabItem;
			bool flag = tabItem != null;
			if (flag)
			{
				TabItem tabItem2 = e.Data.GetData(typeof(TabItem)) as TabItem;
				bool flag2 = tabItem2 != null;
				if (flag2)
				{
					bool flag3 = !tabItem.Equals(tabItem2);
					if (flag3)
					{
						TabControl tabControl = tabItem.Parent as TabControl;
						int insertIndex = tabControl.Items.IndexOf(tabItem2);
						int num = tabControl.Items.IndexOf(tabItem);
						tabControl.Items.Remove(tabItem2);
						tabControl.Items.Insert(num, tabItem2);
						tabControl.Items.Remove(tabItem);
						tabControl.Items.Insert(insertIndex, tabItem);
						tabControl.SelectedIndex = num;
					}
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002AF0 File Offset: 0x00000CF0
		private void FPSRBLX_Click(object sender, RoutedEventArgs e)
		{
			string str = "\\rbxfpsunlocker.exe";
			Process.Start("bin\\" + str);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B18 File Offset: 0x00000D18
		private void Kill_Click(object sender, RoutedEventArgs e)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				bool flag = process.ProcessName == "RobloxPlayerBeta";
				bool flag2 = flag;
				if (flag2)
				{
					process.Kill();
				}
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002B68 File Offset: 0x00000D68
		private void TopM_Checked(object sender, RoutedEventArgs e)
		{
			base.Topmost = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002B73 File Offset: 0x00000D73
		private void TopM_Unchecked(object sender, RoutedEventArgs e)
		{
			base.Topmost = false;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002B7E File Offset: 0x00000D7E
		private void JoinDis_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://discord.gg/VzG7RC4yQF");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002B90 File Offset: 0x00000D90
		private void scripth_Click(object sender, RoutedEventArgs e)
		{
			GameHuy gameHuy = new GameHuy();
			gameHuy.Show();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002BAB File Offset: 0x00000DAB
		private void KrnlAPI_Checked(object sender, RoutedEventArgs e)
		{
			MainAPI.AutoAttach(true);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002BB5 File Offset: 0x00000DB5
		private void KrnlAPI_Unchecked(object sender, RoutedEventArgs e)
		{
			MainAPI.AutoAttach(false);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002BBF File Offset: 0x00000DBF
		private void Frame_Navigated(object sender, NavigationEventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002BC4 File Offset: 0x00000DC4
		private void closeapp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002C00 File Offset: 0x00000E00
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

		// Token: 0x04000001 RID: 1
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000002 RID: 2
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000003 RID: 3
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		// Token: 0x04000005 RID: 5
		private ScrollViewer tabScroller;

		// Token: 0x04000006 RID: 6
		private TextEditor current;
	}
}
