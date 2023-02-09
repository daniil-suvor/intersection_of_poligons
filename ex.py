import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

a,b,c,d = 1,2,3,4

x = np.linspace(-10,10,100)
y = np.linspace(-10,10,100)

t = np.linspace(-2,1,100)
x_line = -14*t - 10
y_line = 4*t + 5.5
z_line = 2*t + 1

X,Y = np.meshgrid(x,y)
Z = (d - a*X - b*Y) / c

fig = plt.figure()
ax = fig.gca(projection='3d')

z = -(11 - X- 4*Y)
surf = ax.plot_surface(X, Y, Z)
surf = ax.plot_surface(X, Y, z)
ax.plot(x_line, y_line, z_line)
plt.show()