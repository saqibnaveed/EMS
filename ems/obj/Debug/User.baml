   M S B A M L   `   `   `  ����>  :ems, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:emsems  5   	       ems.User   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ems     5   	     � Title$
  User��5   	   $	��470��6   $	��440��6&   $	��470��65   $	��440��6B    � AllowsTransparency .   � WindowStyle$
 None=�6i    � WindowStartupLocation$ CenterScreen=�6|    � 	Resources 5       �� 
TargetType   TooltipInError �� Property �� Value �� CornerRadius	 � ToolTip
 �� ElementName �� Path��%P  &	        �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� ���	#ff5c1779$��right=�6<   $��10,0,0,0q�6S   $��24��6e   $��24��6p   $ 14��6|   	 5      �� $
 customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   .v�5   "   �� ���	#ff5c1779$��2q�6A   5      5      5      5      5      5      .��5!      � -   5         �Name$ userBg��5!       � RowDefinitions 5"   
   �� 5#      $	��91* �6   �� 5$      $	��74* �6   �� 5%      $	��66* �6   .+�5(   
   � -   5        $ actionPanelShadow��5(      $��11��6*   $	��Top=�66   $��0,85,0,0q�6N   ��5)      �� 5*       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5+      �  � Color$ 	#FF777777��6#    � Offset$ 0Q�65   � 5,      $ 1Q�6#   5-      50      �� 51   
   -   5         ��Name$ border��51      ���	#FF777777$y�Visible=�67   $��4��6L   $��3��6`   � 52   
   -   5        $ actionPanel��52      ���	#ff777777$��85��6;   $	��Top=�6G    53      �� 54      $	��26* �6    �� 55      $	��59* �6    .+�58      � -   5        $ 	statusbar��58      ���	#22000000$��27��6=   $��Bottom=�6I   $��-1,0,1,0q�6d    59      �� 5:      �� 5;      $��8* �6$   .+�5=      �� -   5         ��Name$ btnMainClose��5=      $,��&E:\Desktop\res\ic_close_white_48dp.png��6.   $��Right=�6^   $��21��6z   $��0,0,6,3q�6�   $��1��6�   �� 5>      -   5        $ btnMainMaximize��5>      $0��*E:\Desktop\res\ic_call_made_white_48dp.png��61   $��Right=�6e   $��21��6�   $��0,0,32,3q�6�   $��1��6�   �� 5?      -   5        $ btnMainMinimze��5?      $-��'E:\Desktop\res\ic_remove_white_48dp.png��60   $��Right=�6a   $��21��6}   $��0,0,58,3q�6�    J� RenderTransformOrigin$ -0.426,0.481&�6�   $��1��6�   6�   �� 5@      -	   5        $ btnMainMove��5@       � Cursor$ SizeAll��6-   $0��*E:\Desktop\res\ic_open_with_white_48dp.png��6>   $��6,0,0,4q�6r   $ -0.426,0.481&�6�   $��1��6�   $
��Left=�6�   $��21��6�   6�   � 5A      -
   5        $ resizeBarUp��5A      $��3��6,   $	��Top=�67    5B      �� 5C      $��0* �6(   �� 5D      $��8 �6(   5F      �� 5G      -   5         ��Name$ statusbarTime��5G      $
��Date��6/   $��163,0q�6>   $��1��6M   
�������$��Center=�6m   $��Center=�6�   5H      �� 5J      -   5        $ btnBack��5J      $1��+E:\Desktop\res\ic_arrow_back_white_48dp.png��6%   $
��Left=�6Z   $��39��6u   $��	10,10,0,0q�6�   $��1��6�   $	��Top=�6�   $��39��6�   $
 Hand��6�   $y�Hidden=�6   �� 5K      -   5        $ actionPanelLabel��5K      $�� ��6.   $
��Left=�69   $��	54,10,0,0q�6T   $��1��6g   $	��Top=�6t   $	��309��6�   $��39��6�   
�������$��21.333(�6�   $
��Bold"�6�   �� 5L      -   5        $ signOffUser��5L      $
 Hand��6)   $+��%E:\Desktop\res\ic_mood_white_48dp.png��67   $��Right=�6�   $��59��6�   $��1��6�   $��0,0,5,0q�6�   5N      � 5P   
   -   5        $ LastLoginScreenShadow��5P      $��100,18,86,25q�6.   ���	#FFCBCBCB$y�Hidden=�6[   $��1��6o   � 5Q   
   -   5        $ LastLoginScreen��5Q      $��100,14,90,27q�6(   ���	#FFE4E4E4$y�Hidden=�6U   $��1��6i   .+�5S      � -   5        $ lastLoginShadow��5S      $��
15,31,8,28q�6,   ���	#FFBDBDBD J� Opacity$
 0.90Q�6W   �� 5T      -   5        $ 	lastLogin��5T      $��Last Login Date��6'   $��Center=�6A   
�������
���   �$��12,30,10,30q�6�   $��Center=�6�   5U      � 5W   
   -   5        $ currentEventScreenShadow��5W      $��58,136,42,56q�61   ���	#FFCBCBCB$y�Hidden=�6^   $��3��6r   � 5X   
   -   5        $ currentEventScreen��5X      $��51,129,44,59q�6+   ���	#FFE4E4E4$y�Hidden=�6X   $��3��6l    � ColumnDefinitions 5Y      �� 5Z      $
��188* �6#   �� 5[      $
��149* �6#    5]      �� 5^      $	��50* �6    �� 5_      $	��87* �6    .+�5a      � -   5        $ currentEventBGShadow��5a      $��28,10,18,11q�61   ���	#FFBDBDBD$
 0.90Q�6]   $��2��6l   $��1��6�    5b      �� 5c      .+�5e      �� -   5        $ currentEventBGTxt��5e      $ Arrow��63   $��Center=�6B   
�������
���   �$��-3,0,3,3q�6�   $��Center=�6�   5f      �� 5g      -   5        $ currentEventImage��5g      $��1��6/   $��10,10,18,10q�6?   5h      � 5j   
   -   5        $ eventDetailScreenShadow��5j      $��58,136,42,56q�60   ���	#FFCBCBCB$y�Hidden=�6]   $��3��6q   � 5k   
   -   5        $ eventDetailScreen��5k      $��51,129,44,59q�6*   ���	#FFE4E4E4$y�Hidden=�6W   $��3��6k    5l      �� 5m      $
��188* �6#   �� 5n      $
��149* �6#    5p      �� 5q      $	��50* �6    �� 5r      $	��87* �6    .+�5t      � -   5        $ eventDetailBGShadow��5t      $��28,10,18,11q�60   ���	#FFBDBDBD$
 0.90Q�6\   $��2��6k   $��1��6    5u      �� 5v      .+�5x      �� -   5        $ eventDetailBGTxt��5x      $ Arrow��62   $��Center=�6A   
�������
���   �$��-3,0,3,3q�6�   $��Center=�6�   $	��150��6�   $��Bottom=�6�   .��5y      �� -   5        $ temporarylabel��5y      $0��*details, also show cost from billing table��64   5z      5{      �� 5|      -   5        $ eventDetailImage��5|      $��1��6.   $��10,10,18,10q�6>   5}      � 5   
   -   5        $ viewEventsScreenShadow��5      $��100,18,86,25q�6/   ���	#FFCBCBCB$y�Hidden=�6\   $��1��6p   .+�5�      �� -   5         ��Name$ listView��5�      $��0,0,0,5q�6)    �� View 5�      �� 5�      .P�5�      �� 5�      5�      5�      � 5�   
   -    5        $ viewEventsScreen��5�      $��53,121,42,67q�6)   ���	#FFE4E4E4$y�Hidden=�6V   $��3��6j    5�      �� 5�       5�      �� 5�      .+�5�      �� -!   5        $ 	eventList��5�      $��36,37,39,36q�6*   ��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      �� $��Center=�6D   $y�Hidden=�6a   ��6(   �� *
C_Event_id+6w   �� 5�      $��Center=�6D   ��6(   �� *
event_name+6c   5�      5�      5�      5�      � 5�   
   -"   5        $ userMainScreenShadow��5�      $��104,139,90,63q�6-   ���	#FFCBCBCB$y�Visible=�6[   $��3��6p   � 5�   
   -#   5        $ userMainScreen��5�      $��96,129,94,67q�6'   ���	#FFE4E4E4$y�Visible=�6T   $��3��6i    5�      �� 5�      $	��88* �6    �� 5�      $	��83* �6    �� 5�      $	��95* �6    .+�5�      � -$   5        $ viewEventBtnShadow��5�      $��
63,36,58,6q�6/   ���	#FFBDBDBD$
 0.90Q�6Z   .+�5�      �� -%   5        $ viewEventsBtn��5�      $
 Hand��6/   $��View Events��6=   $��Center=�6S   
�������
���   �$��	-2,-3,2,2q�6�   $��Center=�6�   6�   5�      � 5�      $��63,19,58,29q�6   ���	#FFBDBDBD$
 0.90Q�6?   $��2��6N   .+�5�      �� -&   5        $ checkLastLoginBtn��5�      $
 Hand��63   $��Check Last Login��6A   $��Center=�6\   
�������
���   �$��	-3,-3,2,2q�6�   $��Center=�6�   6�   5�      � 5�      $��63,25,58,12q�6   ���	#FFBDBDBD$
 0.90Q�6?   $��1��6N   .+�5�      �� -'   5        $ currentEventsBtn��5�      $
 Hand��62   $��Current Event��6@   $��Center=�6X   
�������
���   �$��	-3,-3,2,2q�6�   $��Center=�6�   6�   5�      5�      A� 5�   
   -(   5         A�Name$ 	fabShadow��5�      ���	#66777777$��	0,0,22,21q�66   $��48��6I   $��Bottom=�6U   $��Right=�6p   $��48��6�   $��2��6�   A� 5�   
   -)   5        $ fabBg��5�      ���	#FF777777$��	0,0,24,24q�62   $��48��6E   $��Bottom=�6Q   $��Right=�6l   $��48��6�   $��2��6�   �� 5�   
   -*   5        $ fabTask��5�      $��	0,0,32,32q�6"   $��32��65   $��Bottom=�6A   $��Right=�6\   $��32��6x   $��2��6�   A� 5�   
   -+   5        $	 fab��5�      ���	#00000000$��	0,0,24,24q�60   $��48��6C   $��Bottom=�6O   $��Right=�6j   $��48��6�   $ 0Q�6�   $��2��6�   5�      5�      