   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5	   	   $��1131.966��6   $	��800��6.   .��5
      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��CUSTOMER SALES INVOICE��6   $��16(�66   $
��Bold"�6D   $��Center=�6V   $��	0,10,0,10q�6s   � 5      $��1��6    � ColumnDefinitions 5      �� 5      $��2* �6'   �� 5      $��1* �6'   .+�5      �� $��0��6   $��2��6-   $��0,0,264.6,975.2q�6A   .+�5      �� $��Customer Information:��6    $
��Bold"�6=   $��0,0,0,10q�6O   �� 5       �� Orientation$ 
Horizontal=�6!   .+�5       �� $	��ID:��6$   $��60��6/   �� 5!      -   5         ��Name$ 
CustomerID��5!   $   $	��100��68   5"      �� 5#      $ 
Horizontal=�6!   .+�5$      �� $��Name:��6$   $��60��61   �� 5%      -   5        $ CustomerName��5%   $   $	��200��6:   5&      �� 5'      $ 
Horizontal=�6!   .+�5(      �� $��Address:��6$   $��60��64   �� 5)      -   5        $ CustomerAddress��5)   $   $	��200��6=   5*      5+      �� 5.      $��1��6   $��Right=�6-   $��0,0,-0.4,991.2q�6I   .+�5/      �� $ 
Horizontal=�6!   .+�50      �� $��Invoice ID:��6$   $	��100��67   �� 51      -   5        $ 	InvoiceID��51   $   $	��100��67   52      �� 53      $ 
Horizontal=�6!   .+�54      �� $��Invoice Date:��6$   $	��100��69   �� 55      -   5        $ InvoiceDate��55   $   $	��100��69   56      �� 57      $ 
Horizontal=�6!   .+�58      �� $��Page:��6$   $	��100��61   �� 59      -   5        $ 
PageNumber��59   $   $	��100��68   5:      �� 5;      $ 
Horizontal=�6!   .+�5<      �� $��	Currency:��6$   $	��100��65   �� 5=      $��SR��6$   $	��100��6.   5>      5?      5@      5A      &   System.Windows.Controls.DataGrid  5D   
   -   5          Name$ InvoiceItemsGrid��5D         AutoGenerateColumns .  $��0,134,-0.4,558.4q�6I      Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Line #��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 65     5G      $	 	Item Code��6%   $	
 100 68     5H      $	 Description��6%   $	
 200 6:     5I      $	 Quantity��6%   $	
 100 67     5J      $	 Price��6%   $	
 100 64     5K      $	 Total��6%   $	
 100 64   5M      5P      5Q      