   M S B A M L   `   `   `  ����Q  MVIPArbitrageMissForYou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VIPArbitrageMissForYouVIPArbitrageMissForYou  5      #    VIPArbitrageMissForYou.SignUp   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:VIPArbitrageMissForYou     5        N� Title$  SignUp��5	      .��5      � ��5   
   �� 5       �� ImageSource$  /Resources/background2.jpg��6    j� Stretch$
 Fill=�6C    j� TileMode$
 None=�6R    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��2��6"   $��1��66   $��3��6C   $��1q�6U   
�������._�5      ��  J� Opacity$	 0.5Q�6   ��5       �� 5!       �� 
StartPoint$	 0,1&�6*    �� EndPoint$	 1,0&�6;   .��5"      � 	 � Offset$	 0Q�6'   
 � Color$
 Black��62   � 5#      $		 0.5Q�6'   $

 Gold��64   � 5$      $		 0.8Q�6'   $
 Yellow��64   � 5%      $	 1Q�6'   $
 Black��62   5&      5(      5)      �� 5*   
   $��DemiBold"�6   $��Center=�6'   $��Center=�6B   $��1��6_   $��1��6l   
�������$��Login: ��6�   �� 5+   
   -   5         ��Name$	 log��5+   >   $��23(�6   $��1��6!   $��2��6.   $��Center=�6K   $��0,0,10,0q�6f   �� 5,   
   $��DemiBold"�6   $��Center=�6'   $��Center=�6B   $��2��6_   $��1��6l   
�������$��
Password: ��6�    � ToolTip 5-      �� 5.      
���   �
��� ���.��6=   64Password must be min. 12 symbols and max. 55 symbols6s   50      G� 51   
   -   5         G�Name$ 	passfield��51   a   $��23(�6   $��2��6$   $��2��61    G� PasswordChar$ $��6A    G� 	MaxLength$ 55��6R   $��Center=�6t   $��0,0,10,0q�6�   �� 52   
   -   5        
�������$��3q�52   $   
���   �$��1��6L   $��3��6\   $��Sign up��6i   $��0,42,0,0q�6{   ��53      �� 54      $	 0,1&�6&   $	 1,0&�67   .��55      � $
 Black��6#   $	 0Q�61   � 56      $
 Orange��6#   $	 1Q�62   57      59      �� 5:   
   -   5        
�������$��3q�5:   $   
���   �$��2��6L   $��3��6\   $��Login��6i   $��0,42,0,0q�6y   ��5;      �� 5<      $	 0,1&�6&   $	 1,0&�67   .��5=      � $
 Black��6#   $	 1Q�61   � 5>      $
 Orange��6#   $	 0Q�62   5?      5A      �� 5B   
   -   5        
���   �$��4��5B   9   $��Right=�6I   $	��Top=�6e   $��30��6}   $��30��6�   
��� ���
��� ���$��X��6�   5C      5D      