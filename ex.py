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

# res = np.array([])


dif_x = np.array([-27, 15, -13])
dif = np.array([dif_x, dif_x, dif_x])
vtx1 = np.array([[7, -1, 11], [12, -18, 0], [-1, 11, 10]]) + dif
tri = a3.art3d.Poly3DCollection([vtx1])
tri.set_color(colors.rgb2hex(np.random.rand(3)))
# print(vtx)

ax.add_collection3d(tri)

vtx2 = np.array([[1, -7, 9], [13, 5, 13], [13, 5, 13]]) + dif
tri = a3.art3d.Poly3DCollection([vtx2])
tri.set_color(colors.rgb2hex(np.random.rand(3)))
# print(np.reshape(vtx2, (1, 9)))
ax.add_collection3d(tri)
print(repr(np.concatenate((vtx1, vtx2), axis=None)))
# pl.scatter([0.1], [0], [0.1])
pl.show()
