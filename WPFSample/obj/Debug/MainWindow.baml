   M S B A M L   `   `   `  ����D  @WPFSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFSample	WPFSample  5   	       WPFSample.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFSample     5   	     � Title$  Alert��5   	   $��75��6   $	��450��6#   
������  � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � WindowStartupLocation$ Manual=�5   	    � SizeToContent$ Height=�5   	   .��5      ��  �� CornerRadius$ 10��6   ._�5   
   �� $ 15��6   
����d�$��5q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #462AD8��6#   	 � Offset$	 0Q�63   � 5      $ #DA34AE��6#   $
	 0.75Q�63   � 5      $ #8A16C1��6#   $	 1Q�63   5      ._�5      � 
 � RowDefinitions
 5      �� 5      $
��Auto �6$   .+�5!      �  � ColumnDefinitions 5"      �� 5#      $��10 �6+   �� 5$      $��70 �6+   �� 5%      �� 5&      $��70 �6+   �� 5'      $��10 �6+   .+�5*      �� -   5         ��Name$
 btn1��5*      $��1��5+      ��5.      �� 5/       �� ImageSource$ /Resources/success.png��6)   ��52      �� 53       �� 
TargetType" ��6.   .R�54   "   �� $��60��6)   $��60��64   $ 50��55   %   #��z��56   )   57   #   58      5;      �� 5=      -   5        $
 btn2��5=      $��3��5>      ��5A      �� 5B      $' !/Resources/icons8_cancel_25px.png��6)   ��5E      �� 5F      " ��6.   .R�5G   "   �� $��60��6)   $��60��64   $ 50��5H   %   #��z��5I   )   5J   #   5K      5N      �� 5P      -   5         ��Name$ Label_Message��5P       $��Message Text��5Q       
�������$��25(�5S       $
��Wrap=�5T        �� TextAlignment$ Center=�5U       $��2��5V       $��Center=�5W       $��10q�5X       5Y      5[      5]      5^      5_      