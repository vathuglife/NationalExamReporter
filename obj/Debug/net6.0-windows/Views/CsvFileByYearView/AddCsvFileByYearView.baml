   M S B A M L   `   `   `  ����  NationalExamReporterG    ANationalExamReporter.Views.CsvFileByYearView.AddCsvFileByYearView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$  AddCsvFileByYear��5   	   $	��400��6"   $	��600��6/   .��5      � .+�5	   
   �� $��Step 1. Choose a year��6   $
��Left=�60   $��	36,41,0,0q�6K   $	��Top=�6^   $��20(�6v   �� 5
   
   $��Step 2. Choose a file��6   $
��Left=�60   $��
36,165,0,0q�6K   $	��Top=�6_   $��20(�6w   �� 5   
   -   5         ��Name$ CsvFilePathTextBox��5      $
��Left=�6.   $��
36,227,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��422��6�    J� RenderTransformOrigin$ 0.417,0.531&�6�   $��38��6�    �� 
IsReadOnly$
 True��6�   $��18(�6�   $
��True��6�   " �� VerticalScrollBarVisibility$ Visible=�6
  �� 5   
   -   5         ��Name$ FinishButton��5      $��Finish��6'   $
��Left=�68   $��420,307,0,0q�6S   $	��Top=�6h   $��16(�6�   $��47��6�   $	��125��6�   6�   �� 5   
   -   5        $ ImportCsvButton��5      $��Import��6*   $
��Left=�6;   $��474,227,0,0q�6V   $	��Top=�6k   $��38��6�   $��82��6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ YearComboBox��5      $
��Left=�6)   $��	36,99,0,0q�6D   $	��Top=�6W   $	��520��6o   $��47��6{   $��18(�6�   $
��Bold"�6�   5      5      