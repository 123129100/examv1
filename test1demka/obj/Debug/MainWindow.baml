   M S B A M L   `   `   `  ����E  Atest1demka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:test1demka
test1demka  5   	       test1demka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:test1demka     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��10,10,10,20q�6    � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5   
   �� -   5         ��Name$ 
textSearch��5      $��0��5      $��search��5      $��0,0,0,10q�5      $��5q�5      $��Stretch=�5      �� 5      -   5         ��Name$ cbSort��5       �� SelectedIndex$ 0��5      .@�5      �� .��6   По порядку6+   �� 5      .��6   По порядку (обр)61   �� 5       .��6   По имени6)   �� 5!      .��6   По имени (обр)6/   5"      5#      �� 5%   
   $��1��6   
���   �$��0,0,0,10q�5'      ._�5(      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5(         AutoGenerateColumns .     Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	StartDate��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	startDate+6Z     5,      $	 climateTechModel��6)   $
 * 6j    6C   �� *problemDescryption+6j     5-      $	 climateTechType��6)   $
 * 6w    6B   �� *" climateTechType.climateTechType1+6w     5.      $	 Request Status��6)   $
 * 6u    6A   �� *!requestStatus.requestStatusName+6u   50      51      �� 54   
   $��2��6    �� Orientation$ 
Horizontal=�55      $��Center=�56      $��0,0,0,10q�57      .+�58      �� -   5         ��Name$ btn_add��58      $!��Добавить новый��59      $	��120��5:      $��0,0,10,0q�5;      5<      �� 5=      -   5        $ 
btn_delete��5=      $'��!Удалить выбранное��5>      $	��120��5?      $��0,0,10,0q�5@      5A      �� 5B      -   5        $ 
btn_update��5B      $ ��Редактировать��5C      $	��120��5D      5E      5F      �� 5I   
   $��3��6   $ 
Horizontal=�5J      $��Center=�5K      .+�5L      �� -   5        $��
Назад��5L      $��70��5N      $��0,0,10,0q�5O      �� 5P      -   5         ��Name$ PageInfo��5P      $��Center=�5Q      $	��5,0q�5R      �� 5S      -	   5        $��Вперед��5S      $��70��5U      $��10,0,0,0q�5V      5W      5X      5Y      