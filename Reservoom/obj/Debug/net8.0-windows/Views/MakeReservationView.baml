   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  5      )    #Reservoom.Views.MakeReservationView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservoom.Views     5      .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Make Reservation��6   $	�� 24(�6,   � 5   
   $��1��6   $��0,25,0,0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��Username��6   �� 5      $��1��6   $��0,5,0,0q�6#   ��64   �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�5      � 5   
   $��2��6   $��0,10,0,0q�6    5      �� 5       $
��auto �6    �� 5!      $
��auto �6     � ColumnDefinitions 5#      �� 5$      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   �� 5%      $
��auto �6#   $ SecondColumn��60   .+�5'      �� $��	Floor No.��6   �� 5(      $��1��6   $��0��6#   $��0,5,0,0q�63   ��6D   �� *FloorNumber+$ PropertyChanged=��� 5)      $��Room No.��6   $��1��6(   $��10,0,0,0q�68   �� 5*      $��1��6   $��1��6#   $��10,5,0,0q�63   ��6E   �� *
RoomNumber+$ PropertyChanged=�5,      � 5-   
   $��3��6   $��0,10,0,0q�6    5.      �� 5/      $
��auto �6    �� 50      $
��auto �6     52      �� 53      $
��auto �6#   $ FirstColumn��60   �� 54      $
��auto �6#   $ SecondColumn��60   .+�56      �� $��
Start Date��6   (  "System.Windows.Controls.DatePicker  57      $��1��6   $��0��6&   $��0,5,0,0q�66      SelectedDate 6G   �� *	StartDate+$ PropertyChanged=��� 58      $��End Date��6   $��1��6(   $��10,0,0,0q�68     59      $��1��6   $��1��6&   $��10,5,0,0q�66    6H   �� *	EndDate+$ PropertyChanged=�5;      �� 5=   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0,10,0,0q�6;   .+�5>      �� $��Submit��6   ��6&   �� *SubmitCommand+�� 5?      $��Cancel��6   $��5,0,0,0q�6&   ��67   �� *CancelCommand+5@      5A      5B      