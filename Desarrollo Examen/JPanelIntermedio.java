package TrabajoFinal;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.ArrayList;

public class JPanelIntermedio extends JPanel {

    private ArrayList<Examenes> examenes;
    private JComboBox combobox = new JComboBox();

    public JPanelIntermedio() {
        try {
            ObjectInputStream in = new ObjectInputStream(new FileInputStream("C:/algo/algo.txt"));
            examenes=(ArrayList<Examenes>) (in.readObject());
        } catch (IOException r) {
            System.out.println("ups");
        } catch (ClassNotFoundException l) {
            System.out.println("ups2");
        }
        etiqueta();
        botones();

    }
    public void paintComponent(Graphics g){
        Dimension tam=getSize();
        ImageIcon imagen= new ImageIcon(new ImageIcon(getClass().getResource("/Imagen/imagen1.jpg")).getImage());
        g.drawImage(imagen.getImage(),0,0,tam.width,tam.height,null);
    }

    public void etiqueta() {
        JLabel etiqueta1 = new JLabel();

        combobox.setBounds(90, 50, 100, 30);
        for (Examenes f : this.examenes) {
            combobox.addItem(f);
        }
        add(combobox);

        etiqueta1.setText("Seleccione la Materia");
        etiqueta1.setBounds(45, 10, 500, 20);
        etiqueta1.setFont(new Font("Arial", 1, 20));
        add(etiqueta1);
    }

    public void botones() {
        JButton boton1 = new JButton();

        boton1.setBounds(90, 100, 100, 30);
        boton1.setText("Elegir");
        add(boton1);
        boton1.addActionListener(new oyenteOk());

    }

    private class oyenteOk implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            JFrameDeAlumno alumnos = new JFrameDeAlumno((Examenes) (JPanelIntermedio.this.combobox.getSelectedItem()));
        }
    }

}
