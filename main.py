from models.object_3d import *
from models.camera import *
from models.projection import *
import pygame as pg


class SoftwareRender:
    def __init__(self):
        pg.init()
        self.RES = self.WIDTH, self.HEIGHT = 1280, 720
        self.H_WIDTH, self.H_HEIGHT = self.WIDTH // 2, self.HEIGHT // 2
        self.FPS = 60
        self.screen = pg.display.set_mode(self.RES)
        self.clock = pg.time.Clock()
        self.create_objects()

    def create_objects(self):
        self.camera = Camera(self, [0, 5, -35])
        self.projection = Projection(self)
        self.object = self.get_object_from_file('Modelos3D/mariotroph.obj')
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

    def draw(self, zoom_type: str):
        self.screen.fill(pg.Color('black'))
        self.object.draw(zoom_type)

    def run(self):
        curr_wheel = "none"
        while True:
            self.draw(curr_wheel)
            for event in pg.event.get():
                mouse_pos = pg.mouse.get_pos()
                if event.type == pg.QUIT:
                    exit()
                if event.type == pg.MOUSEBUTTONDOWN:
                    xy1 = (mouse_pos[0] - 10, mouse_pos[1] - 100)
                elif event.type == pg.MOUSEBUTTONUP:
                    xy2 = (mouse_pos[0] - 10, mouse_pos[1] - 100)
                if event.type == pg.MOUSEWHEEL:
                    # x: 0, y: -1 => MOUSEWHEELBACK == "Zoom Out"
                    # x: 0, y: 1 => MOUSEWHEELFRONT == "Zoom In"
                    if event.y == -1:
                        curr_wheel = "in"
                    elif event.y == 1:
                        curr_wheel = "out"
                    else:
                        curr_wheel = "none"
            pg.display.set_caption(str(self.clock.get_fps()))
            pg.display.flip()
            self.clock.tick(self.FPS)
if __name__ == '__main__':
    app = SoftwareRender()
    app.run()