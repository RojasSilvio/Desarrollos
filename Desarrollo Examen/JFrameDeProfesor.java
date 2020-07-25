package TrabajoFinal;

import javax.swing.*;
import java.util.ArrayList;

public class JFrameDeProfesor extends JFrame {

    protected ArrayList<Examenes> ex = new ArrayList<>();
    JPanelDeProfesor panel1 = new JPanelDeProfesor();

    public JFrameDeProfesor() {
        //setDefaultCloseOperation(EXIT_ON_CLOSE);
        setBounds(20, 30, 300, 400);
        setLocationRelativeTo(null);
        setTitle("Examen FINAL");

        panel1.setLayout(null);
        add(panel1);
        setVisible(true);
    }

    public void reiniciar() {
        panel1.removeAll();
        panel1 = new JPanelDeProfesor();
        panel1.setLayout(null);
        add(panel1);
        setVisible(true);
    }

}

