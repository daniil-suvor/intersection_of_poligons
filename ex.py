# import numpy as np
# import matplotlib.pyplot as plt
# from mpl_toolkits.mplot3d import Axes3D

# a,b,c,d = 1,2,3,4

# x = np.linspace(-10,10,100)
# y = np.linspace(-10,10,100)

# t = np.linspace(-2,1,100)
# x_line = -14*t - 10
# y_line = 4*t + 5.5
# z_line = 2*t + 1

# X,Y = np.meshgrid(x,y)
# Z = (d - a*X - b*Y) / c

# fig = plt.figure()
# ax = fig.gca(projection='3d')

# z = -(11 - X- 4*Y)
# surf = ax.plot_surface(X, Y, Z)
# surf = ax.plot_surface(X, Y, z)
# ax.plot(x_line, y_line, z_line)
# plt.show()

import mpl_toolkits.mplot3d as a3
import matplotlib.colors as colors
import pylab as pl
import numpy as np

ax = a3.Axes3D(pl.figure())

vtx = np.array([[0, 1, 0], [1, 0, 20], [10, 0, 0]])
tri = a3.art3d.Poly3DCollection([vtx])
tri.set_color(colors.rgb2hex(np.random.rand(3)))

ax.add_collection3d(tri)

vtx = np.array([[1, 2, 3], [-9, 1, 0], [-1, -2, -3]])
tri = a3.art3d.Poly3DCollection([vtx])
tri.set_color(colors.rgb2hex(np.random.rand(3)))

ax.add_collection3d(tri)

pl.scatter([0.1], [0], [0.1])
pl.show()
