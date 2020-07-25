package TrabajoFinal;

import javax.swing.*;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.util.ArrayList;

public class JFrameDeAlumno extends JFrame {

    public JFrameDeAlumno(Examenes e) {
        setTitle("Examen");
        setBounds(50, 50, 360, 400);
        setLocationRelativeTo(null);

        JPanelDeAlumno panelnuevo = new JPanelDeAlumno(e);
        panelnuevo.setLayout(null);
        add(panelnuevo);
        setVisible(true);
        //addWindowListener(new Eventos());
    }

    private class Eventos extends WindowAdapter {

        @Override
        public void windowClosing(WindowEvent e) {
            JOptionPane.showMessageDialog(null, "EXAMEN FINALIZADO!");
            System.exit(0);
        }

    }
}