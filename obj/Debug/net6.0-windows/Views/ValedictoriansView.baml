   M S B A M L   `   `   `  ����O  KNationalExamReporter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NationalExamReporter.ViewsNationalExamReporter.Views  5   	   3    -NationalExamReporter.Views.ValedictoriansView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:NationalExamReporter.Views     5   	     � Title$  ValedictoriansView��5   	   $	��360��6$   $	��800��61   .��5	      � .+�5   
   �� $3��-Thống kê thông tin thủ khoa các khối��6   $
��Left=�6?   $��
10,119,0,0q�6Z   $	��Top=�6n   $��18(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$! ValedictoriansBriefDataGrid��5      $��10,39,10,230q�68      CanUserAddRows$ false��6N      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Year��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Year+  5      $ A00 (Toán, Lý, Hóa)��6%    6B   �� *A00+  5      $ B00 (Toán, Hóa, Sinh)��6%    6D   �� *B00+  5      $ C00 (Văn, Sử, Địa)��6%    6A   �� *C00+  5      $ D00 (Toán, Văn, Anh)��6%    6C   �� *D00+  5      $ A01 (Toán, Lý, Anh)��6%    6B   �� *A01+5      �� 5   
   $0��*Thống kê điểm thủ khoa các khối��6   $
��Left=�6:   $��10,0,0,0q�6U   $	��Top=�6g   $��18(�6   $
��Bold"�6�     5   
   -   5        $# ValedictoriansDetailsDataGrid��5      $��10,158,10,22q�6:   $ false��6P   �� 5   
   -   5         ��Name$ YearComboBox��5      $
��Left=�6)   $��	580,7,0,0q�6D   $	��Top=�6W   $	��108��5      $��29��6   $��18(�6%    �� Text$ Select��63   6A   �� 5   
   $
��Năm��6   $
��Left=�6   $��	525,5,0,0q�69   $	��Top=�6L   $��18(�6d   $
��Bold"�6r   �� 5   
   -   5         ��Name$ 	SearchBtn��5      $
��Tìm��6   $
��Left=�62   $��	693,7,0,0q�6M   $	��Top=�6`   $��69��6x   $��29��6�   5      5      5       