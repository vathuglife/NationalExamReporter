   M S B A M L   `   `   `  ����  NationalExamReporter)    #NationalExamReporter.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  MainWindowView��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   � $��20q�6   4  .System.Windows.Automation.AutomationProperties   HelpText$ Choose year...��6   .+�5      �� -   5         ��Name$ CurrentCsvFileTextBox��5      $
��Left=�65   $��
143,93,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�5      $	��371��6.   $��18(�6:    �� 
IsReadOnly$
 True��6H   $��30��6Z   �� 5      $��Current CSV File��6   $
��Left=�6/   $��	-5,89,0,0q�6J   $	��Top=�6]   $��18(�5      �� 5      -   5         ��Name$ YearComboBox��5      $
��Left=�6-   $��
522,94,0,0q�6H   $	��Top=�6\   $	��108��5      $��29��6#   $��18(�6/    �� Text$ Select��6=   6K   �� 5      -   5         ��Name$# LoadCsvFromSelectedYearButton��5      $
��Load��6<   $
��Left=�6K   $��
635,93,0,0q�5      $	��Top=�6)   $��30��6A   $��87��6M   ${�False��5      o� 5      $��410,10,0,320q�6   $��48��6)   $	��270��65   .@�5      m� $��
Manage CSV��6   $��44��6/   $��80��6;   .@�5      m� -   5        $��Add CSV��5      60   m� 5      -   5        $��
Delete CSV��5      63   5      m� 5      $��Average Score��6   $��44��62   $��90��6>   .@�5      m� -   5        $��	Calculate��5      62   5      m� 5      $��Valedictorians��6   $��44��63   $��90��6?   .@�5       m� -   5        $��	Calculate��5       62   5!      5"      5#      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ StudentsDataGrid��5$      $��	0,147,0,0q�6-   	   CanUserAddRows$	 false��6@   �� 5%   
   $��380,261,380,125q�6   "  FontAwesome.WPF.ImageAwesome  5&      -	   5        $��LoadingIcon��5&      
   Icon$
 Refresh=�62      Spin$
 True��6A   $��48��6M   $��48��6Y   $y�Hidden=�6d   5'      �� 5(   
   $
��Left=�6   $��	20,20,0,0q�6/   $
��Wrap=�6B   $��National Exam Reporter��6V   $	��Top=�5)      $��30(�6,   $	��210��6:   $
��Bold"�6F   5*      5+      