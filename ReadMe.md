# Charge States

**Charge States** has been implemented to calculate the expected charge states produced once an ion beam passes through a stripping point and aid with optimal charge selection.
The stripping medium can be either gas or carbon foil.
The Z (ion atomic number), m (mass in amu), E (beam energy in MeV) and the initial ionization parameters of the beam, as well as a multiplication factor, need to be specified.

The predictions are made with use of empirical formulas that follow the assumption that the charge state distribution can be approximated with a Gaussian distribution. Under this assumption, the mean charge state q_0 as well as the width d of the charge state distribution after stripping are calculated.

The formulas used for the calculation of the mean charge state and the width of the charge state distribution are: 
* the Nikolaev - Dmitriev formula (Foil stripping) - one of the best formulas for Carbon stripper foils, medium/high Z and few MeV/A
* Sayer's formula (Gas and Foil stripping) - appropriate for heavier elements
* Betz's formula (Foil stripping) - one of the best formulas for Carbon stripper foils, medium/high Z and few MeV/A
* Schiwietz - Schmitt formula (Gas and Foil stripping) - appropriate for elements between He - C. For the calculation of the qmean value Schiwietz's formulas for gas and foil stripping are used, while for the width calculation Schmitt's formula is used.

The formulas are available in the respective file below.

Notes: 
* In the case that a formula doesn't support a combination of element and Energy values an error message appears on the respective table slot.
* The Schiwietz - Schmitt predictions are presented for 2 < z < 6 values, where it derives best results.
* The current version of the program is designed to make calculations under the assumption that either Carbon foils are used 
	   (foil stripper) or Nitrogen (gas stripper).
* If an error of "Missing assembly reference" occurs, go to 
 	Solution Explorer>Right-Click References>Add Reference...>Browse...>OxyPlot-2014.1.240.1\NET45\>Select all .dll>Add 


* Program developed by E. M. Asimakopoulou [Contact: emasi@kth.se]
* This program has been developed as part of the APAPES experiment 
	- Project Coordinator: Prof. Theo J.M. Zouros, Dept. of Physics, University of Crete 
	  [Contact: tzouros@physics.uoc.gr], 
	- http://apapes.physics.uoc.gr/
* Based on "Charge", program by Justin M. Sanders [Fortran] .
* Fits from: 
	- V. S. Nikolaev and I. S. Dmitriev, 1968,  “On the equilibrium charge distribution in heavy element ion beams”, Physics Letters, vol. 28A, pp. 277-278
	- H. D. Betz, 1983, “Heavy- ion charge states”, Academic Press, Applied Atomic Collision Physics (S. Datz, ed.), p. 1
	- RO Sayer, 1977, "Semi-empirical formulas for heavy-ion stripping data", Rev. de Phys. App. 12 (1543)
	- G. Schiwietz and P. L. Grande, 2001, "Improved Charge - State Formulas", Elsevier, Nuclear Instruments and Methods in Physics Research B 175 - 177, 125 - 131
	- C. J. Schmitt, 2010, "Equilibrium charge state distribution of low- z ions incident on thin self- supporting foils", [PhD] Dissertation, Notre Dame, Indiana.
