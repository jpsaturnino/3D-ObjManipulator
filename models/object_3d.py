import pygame as pg
from models.matrix_functions import *
from numba import njit


@njit(fastmath=True)
def any_func(arr, a, b):
    return np.any((arr == a) | (arr == b))


class Object3D:
    def __init__(self, render, vertexes='', faces=''):
        self.render = render
        self.vertexes = np.array([np.array(v) for v in vertexes])
        self.faces = np.array([np.array(face) for face in faces])
        self.translate([0.0001, 0.0001, 0.0001])

        self.font = pg.font.SysFont('Arial', 30, bold=True)
        self.color_faces = [(pg.Color('white'), face) for face in self.faces]
        self.movement_flag, self.draw_vertexes = True, False
        self.label = ''
        self.direction = ""

    def draw(self):
        self.screen_projection()


    def movement(self, mouse_pressed):
        if mouse_pressed:
            print("movimentando")
            # if self.direction == "up":
            #     self.rotate_x((pg.time.get_ticks() % 0.005))
            #     self.movement_flag = False
            # elif self.direction == "left":
            #     self.rotate_x(-(pg.time.get_ticks() % 0.005))
            #     self.movement_flag = False
            # if self.direction == "down":
            #     self.rotate_y(-(pg.time.get_ticks() % 0.005))
            #     self.movement_flag = False
            # if self.direction == "right":
            #     self.rotate_y((pg.time.get_ticks() % 0.005))
            #     self.movement_flag = False

    # Draw with midpoint line render method - bresshan
    def draw_line(self, xy1, xy2, color):
        x1, y1 = xy1
        x2, y2 = xy2

        dx = x2 - x1
        dy = y2 - y1
        if (abs(dx) > abs(dy)):
            if (x1 > x2):
                self.draw_line(xy2, xy1, color)
            else:
                if (dy < 0):
                    declive = -1
                    dy = -dy
                else:
                    declive = 1

                inc_e = 2 * dy
                inc_ne = 2 * dy - 2 * dx
                d = 2 * dy - dx
                y = y1
                for x in range(int(x1), int(x2), 1):
                    pg.draw.circle(self.render.screen, color, (x, y), 1, 1)
                    if (d <= 0):
                        d += inc_e
                    else:
                        d += inc_ne
                        y += declive
        else:
            if (y1 > y2):
                self.draw_line(xy2, xy1, color)
            else:
                if (dx < 0):
                    declive = -1
                    dx = -dx
                else:
                    declive = 1
                inc_e = 2 * dx
                inc_ne = 2 * dx - 2 * dy
                d = 2 * dx - dy
                x = x1
                for y in range(int(y1), int(y2), 1):
                    pg.draw.circle(self.render.screen, color, (x, y), 1, 1)
                    if (d <= 0):
                        d += inc_e
                    else:
                        d += inc_ne
                        x += declive

    def draw_polygon(self, polygon, color):
        self.draw_line(polygon[0], polygon[2], color)
        # self.draw_line(polygon[1], polygon[2], color)

    def screen_projection(self):
        vertexes = self.vertexes @ self.render.camera.camera_matrix()
        vertexes = vertexes @ self.render.projection.projection_matrix
        vertexes /= vertexes[:, -1].reshape(-1, 1)
        vertexes[(vertexes > 2) | (vertexes < -2)] = 0
        vertexes = vertexes @ self.render.projection.to_screen_matrix
        vertexes = vertexes[:, :2]
        for index, color_face in enumerate(self.color_faces):
            color, face = color_face
            polygon = vertexes[face]
            if not any_func(polygon, self.render.H_WIDTH, self.render.H_HEIGHT):
                pg.draw.polygon(self.render.screen, color, polygon, 1)
                # self.draw_polygon(polygon, color) # using bresshan
                if self.label:
                    text = self.font.render(self.label[index], True, pg.Color('white'))
                    self.render.screen.blit(text, polygon[-1])

        if self.draw_vertexes:
            for vertex in vertexes:
                print(vertex)
                if not any_func(vertex, self.render.H_WIDTH, self.render.H_HEIGHT):
                    pg.draw.circle(self.render.screen, pg.Color('white'), vertex, 2)

    def translate(self, pos):
        self.vertexes = self.vertexes @ translate(pos)

    def scale(self, scale_to):
        self.vertexes = self.vertexes @ scale(scale_to)

    def rotate_x(self, angle):
        self.vertexes = self.vertexes @ rotate_x(angle)

    def rotate_y(self, angle):
        self.vertexes = self.vertexes @ rotate_y(angle)

    def rotate_z(self, angle):
        self.vertexes = self.vertexes @ rotate_z(angle)


class Axes(Object3D):
    def __init__(self, render):
        super().__init__(render)
        self.vertexes = np.array([(0, 0, 0, 1), (1, 0, 0, 1), (0, 1, 0, 1), (0, 0, 1, 1)])
        self.faces = np.array([(0, 1), (0, 2), (0, 3)])
        self.colors = [pg.Color('red'), pg.Color('green'), pg.Color('blue')]
        self.color_faces = [(color, face) for color, face in zip(self.colors, self.faces)]
        self.draw_vertexes = False
        self.label = 'XYZ'
