package wgn.workshare.fornecedores.data;

import wgn.workshare.fornecedores.models.Fornecedor;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class FornecedorRepository {
    private static List<Fornecedor> fornecedores = new ArrayList<>();

    public FornecedorRepository(){
        this.seed();
    }

    public void add(Fornecedor fornecedor){
        fornecedores.add(fornecedor);
    }

    public List<Fornecedor> listarFornecedores(){
        return fornecedores;
    }

    public Fornecedor obterFornecedorPorId(UUID id){
        return fornecedores.stream().filter(fornecedor -> fornecedor.getId().equals(id)).findFirst().get();
    }

    public boolean atualizarDadasFornecedor(Fornecedor fornecedorAtualizado){
        Fornecedor fornecedor = this.obterFornecedorPorId(fornecedorAtualizado.getId());
        if(fornecedor == null)
            return false;

        fornecedores.remove(fornecedor);
        fornecedores.add(fornecedorAtualizado);

        return true;
    }

    public boolean removerFornecedor(UUID id){
        Fornecedor fornecedor = this.obterFornecedorPorId(id);
        if(fornecedor == null)
            return false;

        fornecedores.remove(fornecedor);
        return true;
    }

    private void seed(){
        for (int index = 0; index < 10; index++){
            this.add(new Fornecedor("Forncedor: " + index, LocalDateTime.now()));
        }
    }
}
