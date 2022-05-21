from typing import Tuple

from models.object_3d import *
from models.camera import *
from models.projection import *
import pygame as pg
import tkinter
import tkinter.filedialog

def file_dialog():
    """Create a Tk file dialog and cleanup when finished"""
    top = tkinter.Tk()
    top.withdraw()  # hide window
    file_name = tkinter.filedialog.askopenfilename(parent=top)
    top.destroy()
    return file_name

class ObjectManipulator:
    def __init__(self):
        pg.init()
        self.RES = self.WIDTH, self.HEIGHT = 1080, 600
        self.H_WIDTH, self.H_HEIGHT = self.WIDTH // 2, self.HEIGHT // 2
        self.FPS = 60
        self.screen = pg.display.set_mode(self.RES)
        self.clock = pg.time.Clock()
        self.move = [False, False, False]
        self.mouse_point = tuple()
        self.create_objects(filename=file_dialog())

    def create_objects(self, filename = "Modelos3D/mariotroph.obj"):
        self.camera = Camera(self, [0, 5, -35])
        self.projection = Projection(self)
        self.object = self.get_object_from_file(filename)
        # self.object.rotate_y(-math.pi / 4)

    def get_object_from_file(self, filename):
        vertex, faces = [], []
        with open(filename) as f:
            for line in f:
                if line.startswith('v '):
                    vertex.append([float(i) for i in line.split()[1:]] + [1])
                elif line.startswith('f'):
                    faces_ = line.split()[1:]
                    faces.append([int(face_.split('/')[0]) - 1 for face_ in faces_])
        return Object3D(self, vertex, faces)

    def draw(self):
        self.screen.fill(pg.Color('gray10'))
        self.object.draw()

    def object_movement(self):
        # mouse left button pressed
        current_mouse = pg.mouse.get_pos()
        if self.move[0]:
            if current_mouse[0] != self.mouse_point[0] and current_mouse[1] != self.mouse_point[1]:
                # self.object.rotate_x(angle=(current_mouse[1] - self.mouse_point[1]))
                self.object.rotate_y(angle=-(pg.time.get_ticks() % (current_mouse[0] - self.mouse_point[0]) * 0.00005))
        if self.move[2]:
            if current_mouse[0] != self.mouse_point[0] and current_mouse[1] != self.mouse_point[1]:
                # self.object.rotate_x(angle=(current_mouse[1] - self.mouse_point[1]))
                self.object.rotate_x(angle=-(pg.time.get_ticks() % (current_mouse[1] - self.mouse_point[1]) * 0.00005))

    def run(self):
        running = True
        _event = {
            'wheel': ""
        }
        while running:
            self.draw()
            # if the left button is pressed, movement the object
            self.camera.control(event=_event)
            for event in pg.event.get():
                mouse_pos: Tuple[int, int] = pg.mouse.get_pos()
                if event.type == pg.QUIT:
                    running = False
                if event.type == pg.MOUSEBUTTONDOWN:
                    self.move = pg.mouse.get_pressed()
                    self.mouse_point = mouse_pos
                elif event.type == pg.MOUSEBUTTONUP:
                    self.move = [False, False, False]
                if event.type == pg.MOUSEWHEEL:
                    if event.y == -1:  # x: 0, y: -1 => MOUSEWHEELBACK == "Zoom Out"
                        _event['wheel'] = "in"
                    elif event.y == 1:  # x: 0, y: 1 => MOUSEWHEELFRONT == "Zoom In"
                        _event['wheel'] = "out"
                    else:
                        _event['wheel'] = "none"
                self.object_movement()
            pg.display.set_caption(f"FPS: {self.clock.get_fps()}")
            pg.display.flip()
            self.clock.tick(self.FPS)


if __name__ == '__main__':
    app = ObjectManipulator()
    app.run()
