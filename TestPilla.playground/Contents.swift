import UIKit

func getNewCompensation(compensation: Float) -> Float {
    var newCompensation: Float
    
    if compensation <= 1999.99 {
        newCompensation = compensation * 1.2
        return newCompensation
    } else if compensation <= 3999.99 {
        newCompensation = compensation * 1.15
        return newCompensation
    } else if compensation <= 6999.99 {
        newCompensation = compensation * 1.10
        return newCompensation
    } else {
        newCompensation  = compensation * 1.05
        return newCompensation
    }
}

print(getNewCompensation(compensation: 1000))

print(getNewCompensation(compensation: 3999.99))

print(getNewCompensation(compensation: 4000.00))

print(getNewCompensation(compensation: 7000))

