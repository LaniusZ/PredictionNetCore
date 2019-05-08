# .netCore Prueba de concepto de predicción
Se utiliza la libreria Microsoft.ML v 1.0.0
Se genera en base al ejemplo "iris flowers"

La idea es entender como funciona internamente el uso de la libreria.

Luego de hacer el analisis, se puede llegar a la siguiente conclusion:
* Si la prueba es igual a lo que ya existe en el diccionario, por defecto sera seleccionado
* Se basa en aproimacion al mas sercano encontrado en el diccionario

Cual es la clave de la prediccion (cualquier lenguaje)
La calidad y exactitud que pueda tener el diccionario de datos.

Que mejoras veo:
* Trabajar con un margen de error de prediccion (definido) %
* Si se detecta una desviacion (error) que este fuera del margen o en el margen. Debe ser validado con el usuario. Es decir que el usuario verifique la informacion que sea correcta (prediccion) o de lo contrario que rectifique.
* Incrementar el diccionario con el caso anterior.