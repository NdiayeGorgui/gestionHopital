   M S B A M L   `   `   `  ����Z  VProjet_Northern_Lights_Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Projet_Northern_Lights_HospitalProjet_Northern_Lights_Hospital  5   	   6    0Projet_Northern_Lights_Hospital.RemplacerMedecin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Projet_Northern_Lights_Hospital     5   	     � Title$  Remplacer Medecin��5   	   $	��450��6#   $	��800��60   ���	#FFF1E3E3 � WindowStartupLocation$ CenterScreen=�6S   .��5	      � .+�5
   
   �� $!��Médecin à supprimer (ID):��6   $
��Left=�64   $��28��6O   $��	32,32,0,0q�6[   $	��Top=�6n   $	��146��6�   �� 5   
   $+��%Choisir le Médecin remplaçant (ID):��6   $
��Left=�6>   $��34��6Y   $��
383,32,0,0q�6e   $	��Top=�6y   $	��197��6�   �� 5   
   -   5         ��Name$ cboMedecinSup��5      $
��Left=�6*   $��28��6E   $��
201,32,0,0q�6Q   $	��Top=�6e   $	��129��6}   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�    �� DisplayMemberPath$ 	IDMedecin��6�   ��6�   �� 6�   �� 5   
   -   5         ��Name$ btnSupprimer��5      $��	Supprimer��6'   $
��Left=�6;   $��28��6V   $��344,247,0,0q�6b   $	��Top=�6w   $	��140��6�   6�   �� 5   
   -   5        $ cboMedecinRemp��5      $
��Left=�6+   $��28��6F   $��
585,32,0,0q�6R   $	��Top=�6f   $	��129��6~   $
 TrueY�6�   $ 	IDMedecin��6�   ��6�   �� 6�   �� 5   
   $
��Nom:��6   $
��Left=�6   $��24��6:   $��132,107,0,0q�6F   $	��Top=�6[   $��64��6s   �� 5   
   $��Prénom:��6   $
��Left=�6"   $��32��6=   $��132,180,0,0q�6I   $	��Top=�6^   $��77��6v   �� 5   
   -   5         ��Name$ 	txtPrenom��5      $
��Left=�6%   $��32��6@   $��201,180,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��129��6�   {�.  6�   �� 5   
   -   5        $ txtNom��5      $
��Left=�6"   $��32��6=   $��201,107,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��129��6�   {�.   J� RenderTransformOrigin$ 0.348,0.637&�6�   �� 5   
   $
��Nom:��6   $
��Left=�6   $��24��6:   $��503,107,0,0q�6F   $	��Top=�6[   $��64��6s   �� 5   
   $��Prénom:��6   $
��Left=�6"   $��32��6=   $��503,180,0,0q�6I   $	��Top=�6^   $��77��6v   �� 5   
   -   5        $ txtPrenomRemp��5      $
��Left=�6)   $��32��6D   $��585,180,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��129��6�   {�.  6�   �� 5   
   -   5        $ 
txtNomRemp��5      $
��Left=�6&   $��32��6A   $��585,107,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��129��6�   {�.  6�   �� 5   
   $
��Left=�6   $	��135��6+   $��
32,247,0,0q�68   $	��Top=�6L   $	��206��6d   $��images/medecin.jpg��6p   �� 5   
   $
��Left=�6   $	��135��6+   $��561,247,0,0q�68   $	��Top=�6M   $	��206��6e   $��images/medecin.jpg��6q   �� 5   
   $
��Left=�6   $��85��6+   $��344,297,0,0q�67   $	��Top=�6L   $	��160��6d   $ 0.285,0.102&�6p   $��images/remplacer.jpg��6�   5      5      