   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  5      ;"clr-namespace:Reservoom.ConvertersReservoom.Converters  6:   P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 6p   ,    &Reservoom.Views.ReservationListingView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservoom.Views     5      9
converters"clr-namespace:Reservoom.Converters     6:   dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     6p     � 	Resources  5	         BoolConverter>   8Reservoom.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter��%:   &	        &	      �� 5
   
   6'     5   
   69   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��View Reservations��6   $	�� 24(�61   �� 5      $��1��6   $��Make Reservation��6%   $��10 0 0 0q�6@   ��6R   �� *MakeReservationCommand+5      � 5   
   $��1��6   $��0 25 0 0q�6   .+�5      *  $LoadingSpinnerControl.LoadingSpinner     	Thickness$ 5Q�63      Color
 �����   	IsLoading 5    3   �� *	IsLoading+� 5!      y�6   �� *	IsLoading+ �� 	Converter# [ .+�5#      �� 
���  ����6   �� *ErrorMessage+y�5$      �� *
HasError+# [  �� 5&      ��6   �� *Reservations+y�6@   �� *
HasError+# [ ��5'      �� 5(       �� 
TargetType" ��6    .�5)      ��  �� Property � ��	 �� Value$	 Stretch=�6K   5*      
 �� View
 5,      �� 5.      .P�5/      �� $��Room ID��6-    �� CellTemplate 50   "   �� 51   &   .R�52   *   �� $��Center=�6L    �� Padding$ 0 0 20 0q�6i   ��64   �� *roomID+6i   53   '   55      �� 56      $��	User Name��6-    57   "   �� 58   &   .R�59   *   �� $ 0 0 20 0q�6N   ��64   �� *
Username+6N   5:   '   5<      �� 5=      $��
Start Date��6-    5>   "   �� 5?   &   .R�5@   *   �� $ 0 0 20 0q�6O   ��64   �� *	StartTime+6O   5A   '   5C      �� 5D      $��End Date��6-    5E   "   �� 5F   &   .R�5G   *   �� ��64   �� *	EndTime+5H   '   5J      5K      5M      5N      5O      5P      5Q      