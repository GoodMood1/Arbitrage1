   M S B A M L   `   `   `  ����Q  MVIPArbitrageMissForYou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VIPArbitrageMissForYouVIPArbitrageMissForYou  5      *    $VIPArbitrageMissForYou.SpotFinancial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:VIPArbitrageMissForYou     5        N� Title$  SpotFinancial��5	      .��5      � ��5   
   �� 5       �� ImageSource$ /Resources/backgr6.png��6    j� Stretch$
 Fill=�6?    j� TileMode$
 None=�6N    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   o� $��35��6   $	��Top=�6   $��21(�63   $��5��6A   $��0��6U   $
��Bold"�6b   ��5      �� 5       �� 
StartPoint$ 1,0.5&�6&    �� EndPoint$ 0.3,1&�69   .��5       �  � Color$ Black��6#   	 � Offset$	 0Q�61   � 5!      $	 Red��6#   $		 0.5Q�6/   � 5"      $ 
DarkOrange��6#   $	 1Q�66   5#      .@�5%      m� -   5        $
��Home��5%      6>   �� 5&      $��4q�6   
���   �._�5'      m� -   5        $��?��5'      $��Center=�6&   
���  ��
��� ���6t   5(      5)      �� 5*   
   
�������$��23(�6#   $��Center=�61   $��2��6L   $��Center=�6`   .��6}   The Spot financial assistant6�   � 5+   
   $��0,72,0,0q�6   $��2��6&   $��4��66   $��Center=�6J   .+�5,      �� -   5        $��3q�5,      
�������
�������$$��Clear statistic table(history)��6P   $��40��6�   ��5-      �� 5.      $	 0,1&�6*   $	 1,0&�6;   .��5/      � $ Black��6'   $	 0Q�65   � 50      $ Orange��6'   $		 0.4Q�66   � 51      $ Black��6'   $		 0.8Q�65   � 52      $ Orange��6'   $	 1Q�66   53      55      �� 56      -   5        $��3q�56      
�������
�������$%��Update statistic table(history)��6P   ��57      �� 58      $	 0,1&�6*   $	 1,0&�6;   .��59      � $ Black��6'   $	 0Q�65   � 5:      $ Orange��6'   $		 0.4Q�66   � 5;      $ Black��6'   $		 0.8Q�65   � 5<      $ Orange��6'   $	 1Q�66   5=      5?      5@      � 5A   
   
��� ���$��6,0,0,6q�6#   $��1��64   $��3��6A   $��0��6R   $��2��6b    5B      �� 5C      �� 5D      $��0* �6#    5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K      �� 5L      .+�5N      � $��1��6   $��Center=�6%   $��26��6@   .+�5O      �� $	��110��6   $��Long/Short pos: ��6$   �� 5P      -   5        
 ��Name$
 p1��5P      $��80��6'   64   �� 5Q      $	�� - ��6   �� 5R      -   5        $
 p2��5R      $��80��6&   63   5S      � 5T      $��2��6   $��Center=�6%   $��26��6@   .+�5U      �� $	��110��6   $��Time frame: ��6$   �� 5V      -   5        $
 tframe��5V   &   $	��100��6   68   5W      � 5X      $��3��6   $��Center=�6%   $��26��6@   .+�5Y      �� $	��110��6   $��	Ammount: ��6$   �� 5Z      -   5        $	
 vol��5Z      $	��100��6(   66   5[      � 5\      $��4��6   $��Center=�6%   $��26��6@   .+�5]      �� $	��110��6   $��Profit/mash-work: ��6$   �� 5^      $	��100��6   6*   5_      � 5`      $��Center=�6   $��48��63   .+�5a      �� $��60��6   $��
Exchange: ��6#   �� 5b      -	   5         ��Name$ exch1��5b      $��DemiBold"�6*    �� SelectedIndex$ 0��6`   $ �� IsSynchronizedWithCurrentItem$ FalseY�6r   ��6@   �� *	Images1+��5c      �� 5d      .R�5e      ��  �� Orientation$ 
Horizontal=�6)   .+�5f   "   �� $
��25px��6@   ��6(   �� *Img1+6@   �� 5g   "   $��Center=�6F   ��6,   �� *
ImgName1+6F   5h      5i      5k      �� 5l      -
   5        $ Combobox��5l   i   $��DemiBold"�6   $ 0��61   $ FalseY�6C   ��6{   �� *Images+��5m      �� 5n      .R�5o      �� $ 
Horizontal=�6)   .+�5p   "   �� $
��25px��6?   ��6(   �� *Img+6?   �� 5q   "   $��Center=�6E   ��6,   �� *	ImgName+6E   5r      5s      5u      �� 5v      -   5        $ 	Combobox2��5v   i   $��DemiBold"�6   $ 0��61   $ FalseY�6C   ��6|   �� *Images+��5w      �� 5x      .R�5y      �� $ 
Horizontal=�6)   .+�5z   "   �� $
��25px��6?   ��6(   �� *Img+6?   �� 5{   "   $��Center=�6E   ��6,   �� *	ImgName+6E   5|      5}      5      5�      �� 5�      -   5        
�������$��4��5�   (   $��26(�65   $��Start��6C   $��0,55,0,0q�6f   $��2��6x   ��5�      �� 5�      $	 0,1&�6*   $	 1,0&�6;   .��5�      � $ Black��6'   $	 0Q�65   � 5�      $ Orange��6'   $		 0.4Q�66   � 5�      $ Black��6'   $		 0.8Q�65   � 5�      $ Orange��6'   $	 1Q�66   5�      5�      5�      � 5�   
   ���#6918$��3��6"   $��2��66   $��1��6F   $��3��6S   $��10,112,0,10q�6e    5�      �� 5�      $
��134* �6#   62   �� 5�      $
��131* �6#   62   �� 5�      $	��94* �6#   61   �� 5�      $
��111* �6#   62    5�      �� 5�      $	��22* �6    �� 5�      $
��203* �6    .+�5�      �� 
�������$��0��6*   $��2q�6:   ._�5�      �� 
������� �� TextAlignment$ Center=�6/   $��DemiBold"�6F   
���   �Bought6w   5�      �� 5�      
�������$��2q�6)   $��1��6=   $��0,0,2,0q�6M   ._�5�      �� 
�������$ Center=�60   $��DemiBold"�6G   
���   �Sold6v   5�      �� 5�      
�������$��2q�6)   $��2��6=   ._�5�      �� 
�������$ Center=�60   $��DemiBold"�6G   
���   �Profit6x   5�      �� 5�      
�������$��2q�6)   $��3��6=   ._�5�      �� 
�������$ Center=�60   $��DemiBold"�6G   
���   �	Exchanges6{   5�      �� 5�      -   5         ��Name$ bought��5�   M   $��Disabled=�6   $��DemiBold"�6]   ���	#02FFFFFF$��Center=�6�   $��0��6�   $��1��6�    � 	Resources 5�       �� 
TargetType �� Property �� Value��%�   '��       �� 5�      " ��6   .�5�      ��  � ��
 �����68   �� 5�       � ��
 �����67   �� 5�       � ��$ 2q�6<   5�      5�      5�      �� 5�      -   5        $
 sold��5�   L   $��Disabled=�6   $��DemiBold"�6Z   ���	#02FFFFFF$��Center=�6�   $��1��6�   $��1��6�    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � ��
 �����68   �� 5�       � ��
 �����67   �� 5�       � ��$ 2q�6<   5�      5�      5�      �� 5�      -   5        $ profitt��5�   L   $��Disabled=�6   $��DemiBold"�6]   ���	#02FFFFFF$��Center=�6�   $��2��6�   $��1��6�    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � ��
 �����68   �� 5�       � ��
 �����67   �� 5�       � ��$ 2q�6<   5�      5�      5�      �� 5�      -   5        $ exchange��5�   L   $��Disabled=�6   $��DemiBold"�6^   ���	#02FFFFFF$��Center=�6�   $��3��6�   $��1��6�    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � ��
 �����68   �� 5�       � ��
 �����67   �� 5�       � ��$ 2q�6<   5�      5�      5�      5�      � 5�   
   $��1��6   $��2��6!   $��3��61   $��Center=�6E   $��Center=�6b    5�      ��%L  '��       '�� o     �� 5�      " ��6   .�5�      ��  � ��
 �����63   �� 5�       � ��$	 120��6.   5�      �� 5�      " ��6   .�5�      ��  � ��
 �����63   �� 5�       � ��$	 100��6.   �� 5�       �@��TextAlignment$ Center=�66   �� 5�       � ��$ 20��6/   5�      5�      .+�5�      � .+�5�      �� $��Time: ��6   �� 5�      -   5         ��Name$
 time��5�      6,   �� 5�      $��Investments: ��6   �� 5�      -   5        $ invest��5�      6/   5�      � 5�      .+�5�      �� $��Total profit: ��6   �� 5�      -   5        $ 	totalprof��5�      61   �� 5�      $��Profit/mash-work: ��6   �� 5�      -   5        $ profmashwork��5�      64   5�      5�      5�      5�      