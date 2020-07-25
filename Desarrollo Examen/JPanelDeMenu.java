package TrabajoFinal;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class JPanelDeMenu extends JPanel {
    public JPanelDeMenu() {
        etiqueta();
        botones();

    }
    public void paintComponent(Graphics g){
        Dimension tam=getSize();
        ImageIcon imagen= new ImageIcon(new ImageIcon(getClass().getResource("/Imagen/imagen7.jpg")).getImage());
        g.drawImage(imagen.getImage(),0,0,tam.width,tam.height,null);
    }
    public void etiqueta(){
        JLabel etiqueta1 = new JLabel();

        etiqueta1.setText("Sistema Academico");
        etiqueta1.setBounds(35, 20, 500, 20);
        etiqueta1.setFont(new Font("Arial",3,25));
        add(etiqueta1);
    }


    JButton boton1= new JButton();

    public void botones(){
        JButton boton2 = new JButton();

        boton1.setBounds(90, 100, 100, 30);
        boton1.setText("Profesor");
        boton1.setOpaque(false);
        boton1.setContentAreaFilled(false);
        add(boton1);
        boton1.addActionListener(new oyenteProfesor());

        boton2.setBounds(90, 200, 100, 30);
        boton2.setText("Alumno");
        boton2.setOpaque(false);
        boton2.setContentAreaFilled(false);
        add(boton2);
        boton2.addActionListener(new oyenteAlumno());
    }
    private class oyenteProfesor implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            JFrameDeProfesor profesorframe = new JFrameDeProfesor();
            profesorframe.setVisible(true);
            boton1.setEnabled(false);

        }
    }

    private class oyenteAlumno implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            JFrameIntermedio r = new JFrameIntermedio();
            r.setVisible(true);
        }
    }
}